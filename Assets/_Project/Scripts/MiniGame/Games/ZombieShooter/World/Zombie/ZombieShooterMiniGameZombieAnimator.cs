using _Project.Scripts.Utilities;
using RSG;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
	public class ZombieShooterMiniGameZombieAnimator : BaseAnimator
	{
		[SerializeField]
		private AnimationClip _idleAnimation = null!;
		[SerializeField]
		private AnimationClip _walkAnimation = null!;
		[SerializeField]
		private AnimationClip _deathAnimation = null!;
		
		public void PlayIdle()
		{
			Play(_idleAnimation, true).Done();
		}

		public void PlayWalk()
		{
			Play(_walkAnimation, true).Done();
		}

		public IPromise PlayDeath()
		{
			return Play(_deathAnimation);
		}
	}
}
