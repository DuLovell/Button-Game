using System;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameController : MonoBehaviour, IMiniGame
	{
		public event Action? OnFinished;
		public event Action? OnShowEnded;
		
		private MiniGameAnimator _miniGameAnimator = null!;
		
		public void StartGame()
		{
			_miniGameAnimator.PlayIdle();
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
