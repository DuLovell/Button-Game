using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameController : MonoBehaviour, IMiniGame
	{
		[Inject]
		private TestMiniGameLogic _miniGameLogic = null!;
		[Inject]
		private TestMiniGameMediator _miniGameMediator = null!;

		private MiniGameAnimator _miniGameAnimator = null!;
		
		public event Action? OnFinished;
		public event Action? OnShowEnded;

		public void StartGame()
		{
			_miniGameAnimator.PlayIdle();
			_miniGameMediator.Active();
			_miniGameLogic.StartGame();
		}

		public void StopGame()
		{
		}

		private void Awake()
		{
			_miniGameAnimator = GetComponent<MiniGameAnimator>();
		}

		private void Start()
		{
			_miniGameAnimator.PlayShow(() => {
				_miniGameAnimator.PlayWaitStart();
				OnShowEnded?.Invoke();
			});
		}

		public MiniGameType GameType
		{
			get { return MiniGameType.FILL_WITHOUT_EXPLODE; }
		}
	}
}
