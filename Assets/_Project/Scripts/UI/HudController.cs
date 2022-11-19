using _Project.Scripts.MiniGame;
using _Project.Scripts.MiniGame.Common;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
	public class HudController : MonoBehaviour
	{
		[Inject]
		private MiniGamesLauncher _miniGamesLauncher = null!;
		[Inject]
		private GameView _gameView = null!;
		
		private IMiniGame _miniGame = null!;

		private void Awake()
		{
			_miniGamesLauncher.OnMiniGameLaunched += OnMiniGameLaunched;
		}

		private void OnMiniGameLaunched(IMiniGame miniGame)
		{
			_gameView.gameObject.SetActive(false);

			_miniGame = miniGame;
			_miniGame.OnFinished += OnMiniGameFinished;
		}

		private void OnMiniGameFinished(bool win)
		{
			_gameView.gameObject.SetActive(true);
			_miniGame.OnFinished -= OnMiniGameFinished;
		}
	}
}
