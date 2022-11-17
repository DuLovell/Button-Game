using System;
using _Project.Scripts.Services.Logger;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games
{
	//TODO Сделать все инжекты интерфейсами, а этот класс сделать абстрактным
	public class TestMiniGameController : MonoBehaviour, IMiniGame
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<TestMiniGameController>();
		
		[Inject]
		private TestMiniGameLogic _miniGameLogic = null!;
		[Inject]
		private TestMiniGameMediator _miniGameMediator = null!;

		public event Action<bool>? OnFinished;
		
		private MiniGameAnimator _miniGameAnimator = null!;

		private void Awake()
		{
			_miniGameAnimator = GetComponent<MiniGameAnimator>();
		}

		private void Start()
		{
			_logger.Debug($"Will show mini game. type={GameType}");
			_miniGameAnimator.PlayShow(OnMiniGameShowEnded);
		}

		private async void OnMiniGameShowEnded()
		{
			_miniGameAnimator.PlayWaitStart();
			
			//TODO Ожидать нажатия на экран
			//TODO Во время ожидания показать туториал, если он требуется
			await UniTask.Delay(TimeSpan.FromSeconds(3), DelayType.DeltaTime);
			
			StartGame();
		}

		private void OnGameFinished(bool win)
		{
			_logger.Debug($"Mini game finished. type={GameType}, win={win}");

			HideGame();
			_miniGameMediator.Deactivate();
			OnFinished?.Invoke(win);

			_miniGameLogic.OnGameFinished -= OnGameFinished;
		}

		private void StartGame()
		{
			_miniGameAnimator.PlayIdle();
			_miniGameMediator.Active();
			
			_miniGameLogic.StartGame();
			_miniGameLogic.OnGameFinished += OnGameFinished;
			
			_logger.Debug($"Mini game started. type={GameType}");
		}

		private void HideGame()
		{
			_logger.Debug($"Will hide mini game. type={GameType}");
			_miniGameAnimator.PlayHide();
		}

		public MiniGameType GameType
		{
			get { return MiniGameType.FILL_WITHOUT_EXPLODE; }
		}
	}
}
