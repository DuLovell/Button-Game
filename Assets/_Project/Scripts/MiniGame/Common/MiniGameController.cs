using System;
using _Project.Scripts.Services.Logger;
using _Project.Scripts.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using IPromise = RSG.IPromise;

namespace _Project.Scripts.MiniGame.Common
{
	public abstract class MiniGameController : MonoBehaviour, IMiniGame
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<MiniGameController>();
		
		[Inject]
		protected IMiniGameLogic _miniGameLogic = null!;
		[Inject]
		protected IMiniGameMediator _miniGameMediator = null!;
		[Inject]
		protected IMiniGameModel _miniGameModel = null!;
		[Inject]
		protected IMiniGameView _miniGameView = null!;
		[Inject]
		private ReadyOverlay _miniGameReadyOverlay = null!;

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
			_miniGameMediator.Activate();
			
			_miniGameLogic.StartGame();
			_miniGameLogic.OnGameFinished += OnGameFinished;
			
			_logger.Debug($"Mini game started. type={GameType}");
		}

		private IPromise HideGame()
		{
			_logger.Debug($"Will hide mini game. type={GameType}");
			return _miniGameAnimator.PlayHide()
			                        .Then(() => {
				                        _miniGameView.DestroyView();
				                        Destroy(_miniGameReadyOverlay.gameObject);
				                        Destroy(gameObject);
			                        });
		}

		public abstract MiniGameType GameType
		{
			get;
		}
	}
}
