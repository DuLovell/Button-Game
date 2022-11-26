using System;
using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Descriptor;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Model;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie;
using _Project.Scripts.Services.Logger;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.Logic
{
	[UsedImplicitly]
	public class ZombieShooterMiniGameLogic : IMiniGameLogic
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<ZombieShooterMiniGameLogic>();
		
		[Inject] 
		private ZombieShooterMiniGameDescriptor _gameDescriptor = null!;
		[Inject] 
		private ZombieShooterMiniGameModel _gameModel = null!;

		public event Action? OnGameStarted;
		public event Action<bool>? OnGameFinished;

		private ZombieShooterMiniGameWorld _gameWorld = null!;

		public void StartGame()
		{
			_gameWorld = Object.FindObjectOfType<ZombieShooterMiniGameWorld>();
			foreach (ZombieShooterMiniGameZombie zombie in _gameWorld.Zombies) {
				zombie.OnKilled += OnZombieKilled;
			}
			_gameModel.ZombieLeftCount = _gameWorld.Zombies.Count;
			
			_gameModel.AmmoCount = _gameDescriptor.StartAmmoCount;
			_gameModel.AimMoveSpeed = _gameDescriptor.StartAimMoveSpeed;
			
			//TODO Дать команду миру запустить зомби в комнату
			OnGameStarted?.Invoke();
		}

		public void OnMainButtonPressed()
		{
			Fire();
			CheckWin();
			CheckLose();
		}

		private void OnZombieKilled(bool headshot)
		{
			if (headshot) {
				_gameModel.AmmoCount++;
			}
			_gameModel.ZombieLeftCount--;
			_logger.Debug($"Zombie killed. headshot={headshot}, ammoCount={_gameModel.AmmoCount}, zombieKilledCount={_gameModel.ZombieLeftCount}");
		}
		
		private void Fire()
		{
			Ray fireRay = _gameWorld.TVScreenCamera.ScreenPointToRay(_gameModel.AimPosition);
			if (Physics.Raycast(fireRay, out RaycastHit hit) && hit.collider.TryGetComponent(out IShootable shootable)) {
				shootable.Shoot();
			}
			_gameModel.AmmoCount--;
			
			_logger.Debug($"Fire. aimPosition={_gameModel.AimPosition}, ammoCount={_gameModel.AmmoCount} ");
		}

		private void CheckLose()
		{
			if (_gameModel.AmmoCount <= 0) {
				OnGameFinished?.Invoke(false);
			}
		}

		private void CheckWin()
		{
			if (_gameModel.ZombieLeftCount <= 0) {
				OnGameFinished?.Invoke(true);
			}
		}
	}
}
