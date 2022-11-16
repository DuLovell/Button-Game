using System;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGame : MonoBehaviour, IMiniGame
	{
		public event Action? OnFinished;
		public event Action? OnShowEnded;
		
		private MiniGameAnimator _miniGameAnimator = null!;
		
		public void StartGame()
		{
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
			_miniGameAnimator.PlayShow(() => OnShowEnded?.Invoke());
		}

		public MiniGameType GameType
		{
			get { return MiniGameType.FILL_WITHOUT_EXPLODE; }
		}
	}
}
