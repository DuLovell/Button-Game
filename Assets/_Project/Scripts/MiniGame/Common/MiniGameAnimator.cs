using _Project.Scripts.Utilities;
using RSG;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Common
{
	public class MiniGameAnimator : BaseAnimator
	{
		[SerializeField]
		private AnimationClip _showAnimation = null!;
		[SerializeField]
		private AnimationClip _hideAnimation = null!;
		[SerializeField]
		private AnimationClip _waitStartAnimation = null!;
		[SerializeField]
		private AnimationClip _idleAnimation = null!;

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
	}
}
