using System;
using _Project.Scripts.MiniGame.Data;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MiniGame
{
	// Решает, когда и какую игру подсунуть игроку
	public class MiniGamesLauncher : MonoBehaviour
	{
		[Inject]
		private MiniGamesLauncherDescriptor _launcherDescriptor = null!;
		[Inject]
		private MiniGameFactory _miniGameFactory = null!;
		
		private DateTime _lastMiniGameFinishTime;
		private DateTime _nextMiniGameStartTime;
		
		private void Start()
		{
			OnMiniGameFinished();
		}

		private void Update()
		{
			if (_nextMiniGameStartTime > DateTime.Now) {
				StartMiniGame();
			}
		}

		private void OnMiniGameFinished()
		{
			_lastMiniGameFinishTime = DateTime.Now;
			_nextMiniGameStartTime = _lastMiniGameFinishTime.AddSeconds(Random.Range(_launcherDescriptor.LaunchDelayRange.x,
			                                                                         _launcherDescriptor.LaunchDelayRange.y));
		}

		private void StartMiniGame()
		{
			IMiniGame miniGame = _miniGameFactory.CreateMiniGame(MiniGameType.FILL_WITHOUT_EXPLODE);
			//TODO Подождать конца Show анимации у мини-игры
			//TODO Показать обратный отсчет
			//TODO Подписаться на событие конца мини-игры OnMiniGameFinished
			//TODO Запустить мини-игру
		}
	}
}
