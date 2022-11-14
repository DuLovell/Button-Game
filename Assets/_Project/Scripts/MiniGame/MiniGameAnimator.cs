using System;
using Animancer;
using UnityEngine;

namespace _Project.Scripts.MiniGame
{
	public class MiniGameAnimator : MonoBehaviour
	{
		[SerializeField]
		private AnimationClip _showAnimation = null!;
		[SerializeField]
		private AnimationClip _hideAnimation = null!;
		[SerializeField]
		private AnimationClip _idleAnimation = null!;

		private AnimancerComponent _animancer = null!;

		public void PlayShow(Action? onComplete = null)
		{
			Play(_showAnimation, onComplete);
		}

		public void PlayHide(Action? onComplete = null)
		{
			Play(_hideAnimation, onComplete);
		}

		public void PlayIdle(Action? onComplete = null)
		{
			Play(_idleAnimation, onComplete);
		}

		private void Awake()
		{
			_animancer = GetComponent<AnimancerComponent>();
		}

		private void Play(AnimationClip clip, Action? onComplete)
		{
			AnimancerState state = _animancer.Play(clip);
			state.Events.NormalizedEndTime = clip.length;
			if (onComplete != null) {
				state.Events.OnEnd = onComplete;
			}
		}
	}
}
