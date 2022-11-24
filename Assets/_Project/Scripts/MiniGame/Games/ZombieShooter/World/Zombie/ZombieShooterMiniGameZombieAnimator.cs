using _Project.Scripts.Utilities;
using Animancer;
using RSG;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
	public class ZombieShooterMiniGameZombieAnimator : BaseAnimator
	{
		[SerializeReference]
		private ClipTransitionAsset _idleAnimation = null!;
		[SerializeReference]
		private ClipTransitionAsset _walkAnimation = null!;
		[SerializeReference]
		private ClipTransitionAsset _deathAnimation = null!;
		
		public void PlayIdle()
		{
			Play(_idleAnimation);
		}

		public void PlayWalk()
		{
			Play(_walkAnimation);
		}

		public void PlayDeath()
		{
			Play(_deathAnimation);
		}
	}
}
