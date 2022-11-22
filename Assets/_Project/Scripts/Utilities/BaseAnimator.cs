using Animancer;
using RSG;
using UnityEngine;

namespace _Project.Scripts.Utilities
{
	public abstract class BaseAnimator : MonoBehaviour
	{
		private AnimancerComponent _animancer = null!;

		protected virtual void Awake()
		{
			_animancer = GetComponent<AnimancerComponent>();
		}

		protected IPromise Play(AnimationClip clip, bool looping = false)
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
