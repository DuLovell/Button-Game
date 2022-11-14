using System;
using _Project.Scripts.Managers.Logger;
using _Project.Scripts.MiniGame.Data;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MiniGame
{
	// Решает, когда и какую игру подсунуть игроку
	public class MiniGamesLauncher : MonoBehaviour
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<MiniGamesLauncher>();
		
		[Inject]
		private MiniGamesLauncherDescriptor _launcherDescriptor = null!;
		[Inject]
		private MiniGameFactory _miniGameFactory = null!;
		
		private DateTime _lastMiniGameFinishTime;
		private DateTime _nextMiniGameStartTime;
		private IMiniGame? _currentMiniGame;

		private void Start()
		{
			OnMiniGameFinished();
		}

		private void Update()
		{
			if (_nextMiniGameStartTime < DateTime.Now) {
				StartMiniGame();
			}
		}

		private void OnMiniGameFinished()
		{
			_lastMiniGameFinishTime = DateTime.Now;
			_nextMiniGameStartTime = _lastMiniGameFinishTime.AddSeconds(Random.Range(_launcherDescriptor.LaunchDelayRange.x,
			                                                                         _launcherDescriptor.LaunchDelayRange.y));

			if (_currentMiniGame == null) {
				_logger.Warn("Current mini game is null");
				return;
			}
			_currentMiniGame.OnShowEnded -= OnMiniGameShowEnded;
			_currentMiniGame.OnFinished -= OnMiniGameFinished;
			_currentMiniGame = null;
		}

		private void StartMiniGame()
		{
			_currentMiniGame = _miniGameFactory.CreateMiniGame(MiniGameType.FILL_WITHOUT_EXPLODE);

			_currentMiniGame.OnShowEnded += OnMiniGameShowEnded;
			_currentMiniGame.OnFinished += OnMiniGameFinished;
		}

		private void OnMiniGameShowEnded()
		{
			//TODO Показать обратный отсчет через UniTask (нужна такая панель)
			//TODO Показать туториал во время отсчета, если он требуется
			
			
			if (_currentMiniGame == null) {
				_logger.Warn("Current mini game is null");
				return;
			}
			_currentMiniGame.StartGame();
		}
	}
}
