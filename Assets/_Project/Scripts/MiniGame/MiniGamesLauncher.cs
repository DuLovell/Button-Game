using System;
using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Data;
using _Project.Scripts.Services.Logger;
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

		public event Action<IMiniGame>? OnMiniGameLaunched;
		
		private DateTime _lastMiniGameFinishTime;
		private DateTime _nextMiniGameStartTime;
		private IMiniGame? _currentMiniGame;
		private bool _miniGameStarted;

		private void Start()
		{
			CalculateNextMiniGameTime();
		}

		private void Update()
		{
			if (!_miniGameStarted && _nextMiniGameStartTime < DateTime.Now) {
				LaunchMiniGame();
			}
		}

		private void OnMiniGameFinished(bool win)
		{
			CalculateNextMiniGameTime();

			if (_currentMiniGame == null) {
				_logger.Warn("Current mini game is null");
				return;
			}
			_currentMiniGame.OnFinished -= OnMiniGameFinished;
			_currentMiniGame = null;
			
			_miniGameStarted = false;
		}

		private void LaunchMiniGame()
		{
			_miniGameStarted = true;
			_currentMiniGame = _miniGameFactory.CreateMiniGame(MiniGameType.FILL_WITHOUT_EXPLODE);
			OnMiniGameLaunched?.Invoke(_currentMiniGame);

			_currentMiniGame.OnFinished += OnMiniGameFinished;
		}

		private void CalculateNextMiniGameTime()
		{
			_lastMiniGameFinishTime = DateTime.Now;
			_nextMiniGameStartTime = _lastMiniGameFinishTime.AddSeconds(Random.Range(_launcherDescriptor.LaunchDelayRange.x,
			                                                                         _launcherDescriptor.LaunchDelayRange.y));
		}
	}
}
