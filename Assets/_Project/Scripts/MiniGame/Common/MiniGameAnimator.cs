using Animancer;
using RSG;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Common
{
	public class MiniGameAnimator : MonoBehaviour
	{
		[SerializeField]
		private AnimationClip _showAnimation = null!;
		[SerializeField]
		private AnimationClip _hideAnimation = null!;
		[SerializeField]
		private AnimationClip _waitStartAnimation = null!;
		[SerializeField]
		private AnimationClip _idleAnimation = null!;

		private AnimancerComponent _animancer = null!;

		public IPromise PlayShow()
		{
			return Play(_showAnimation);
		}

		public IPromise PlayHide()
		{
			return Play(_hideAnimation);
		}
		
		public void PlayWaitStart()
		{
			Play(_waitStartAnimation, true).Done();
		}

		public void PlayIdle()
		{
			Play(_idleAnimation, true).Done();
		}

		private void Awake()
		{
			_animancer = GetComponent<AnimancerComponent>();
		}

		private IPromise Play(AnimationClip clip, bool looping = false)
		{
			AnimancerState state = _animancer.Play(clip);
			state.Events.NormalizedEndTime = clip.length;
			Promise promise = new();
			if (!looping) {
				state.Events.OnEnd = () => promise.Resolve();
			}
			return promise;
		}
	}
}
