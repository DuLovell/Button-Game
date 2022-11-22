using System;
using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World;
using JetBrains.Annotations;
using Object = UnityEngine.Object;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.Logic
{
	[UsedImplicitly]
	public class ZombieShooterMiniGameLogic : IMiniGameLogic
	{
		public event Action<bool>? OnGameFinished;

		private ZombieShooterMiniGameWorld _gameWorld = null!;
		
		public void StartGame()
		{
			_gameWorld = Object.FindObjectOfType<ZombieShooterMiniGameWorld>();
			
			//TODO Инициализировать модель данными из дескриптора
			//TODO Дать команду миру запустить зомби в комнату
			//TODO Дать команду View запустить движение прицела
		}

		public void OnMainButtonPressed()
		{
			//TODO Выстрелить в место прицела
		}
		
		//TODO Проигрыш, если не осталось патронов
	}
}
