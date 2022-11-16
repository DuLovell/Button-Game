﻿using System;
using _Project.Scripts.MiniGame.Data;
using _Project.Scripts.Services.Logger;
using Cysharp.Threading.Tasks;
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
		private bool _miniGameStarted;

		private void Start()
		{
			CalculateNextMiniGameTime();
		}

		private void Update()
		{
			if (!_miniGameStarted && _nextMiniGameStartTime < DateTime.Now) {
				StartMiniGame();
			}
		}

		private void OnMiniGameFinished()
		{
			CalculateNextMiniGameTime();

			if (_currentMiniGame == null) {
				_logger.Warn("Current mini game is null");
				return;
			}
			_currentMiniGame.OnShowEnded -= OnMiniGameShowEnded;
			_currentMiniGame.OnFinished -= OnMiniGameFinished;
			_currentMiniGame = null;
			
			_miniGameStarted = false;
		}

		private async void OnMiniGameShowEnded()
		{
			//TODO Ожидать нажатия на экран
			//TODO Во время ожидания показать туториал, если он требуется
			await UniTask.Delay(TimeSpan.FromSeconds(3), DelayType.DeltaTime);
			
			if (_currentMiniGame == null) {
				_logger.Warn("Current mini game is null");
				return;
			}
			_currentMiniGame.StartGame();
		}

		private void StartMiniGame()
		{
			_miniGameStarted = true;
			_currentMiniGame = _miniGameFactory.CreateMiniGame(MiniGameType.FILL_WITHOUT_EXPLODE);

			_currentMiniGame.OnShowEnded += OnMiniGameShowEnded;
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
