using System;
using _Project.Scripts.MiniGame.Games.Ui;
using _Project.Scripts.Services.Logger;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using IPromise = RSG.IPromise;

namespace _Project.Scripts.MiniGame.Games.Common
{
	//TODO Сделать все инжекты интерфейсами, а этот класс сделать абстрактным
	public class TestMiniGameController : MonoBehaviour, IMiniGame
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<TestMiniGameController>();
		
		[Inject]
		private TestMiniGameLogic _miniGameLogic = null!;
		[Inject]
		private TestMiniGameMediator _miniGameMediator = null!;
		[Inject]
		private TestMiniGameModel _miniGameModel = null!;
		[Inject]
		private TestMiniGameView _miniGameView = null!;
		[Inject]
		private TestMiniGameReadyOverlay _miniGameReadyOverlay = null!;

		public event Action<bool>? OnFinished;
		
		private MiniGameAnimator _miniGameAnimator = null!;

		private void Awake()
		{
			_miniGameAnimator = GetComponent<MiniGameAnimator>();
		}

		private void Start()
		{
			_miniGameModel.Reset();
			_logger.Debug($"Will show mini game. type={GameType}");
			_miniGameAnimator.PlayShow()
			                 .Then(() => OnMiniGameShowEndedAsync().Forget())
			                 .Done();
		}

		private async UniTaskVoid OnMiniGameShowEndedAsync()
		{
			_miniGameAnimator.PlayWaitStart();
			//TODO Во время ожидания показать туториал, если он требуется
			await _miniGameReadyOverlay.ShowAsync();
			StartGame();
		}

		private void OnGameFinished(bool win)
		{
			_logger.Debug($"Mini game finished. type={GameType}, win={win}");

			_miniGameMediator.Deactivate();
			HideGame().Then(() => {
				          OnFinished?.Invoke(win);
				          _miniGameLogic.OnGameFinished -= OnGameFinished;
			          })
			          .Done();
		}

		private void StartGame()
		{
			_miniGameAnimator.PlayIdle();
			_miniGameMediator.Active();
			
			_miniGameLogic.StartGame();
			_miniGameLogic.OnGameFinished += OnGameFinished;
			
			_logger.Debug($"Mini game started. type={GameType}");
		}

		private IPromise HideGame()
		{
			_logger.Debug($"Will hide mini game. type={GameType}");
			return _miniGameAnimator.PlayHide()
			                        .Then(() => {
				                        Destroy(_miniGameView.gameObject);
				                        Destroy(_miniGameReadyOverlay.gameObject);
				                        Destroy(gameObject);
			                        });
		}

		public MiniGameType GameType
		{
			get { return MiniGameType.FILL_WITHOUT_EXPLODE; }
		}
	}
}
