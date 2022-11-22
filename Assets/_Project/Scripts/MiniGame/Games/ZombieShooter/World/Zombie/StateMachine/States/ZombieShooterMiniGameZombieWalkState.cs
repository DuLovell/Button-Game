using FSM;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie.StateMachine.States
{
	public class ZombieShooterMiniGameZombieWalkState : State
	{
		private readonly ZombieShooterMiniGameZombieAnimator _zombieAnimator;
		private readonly ZombieShooterMiniGameZombieMovement _zombieMovement;

		public ZombieShooterMiniGameZombieWalkState(ZombieShooterMiniGameZombieAnimator zombieAnimator,
		                                            ZombieShooterMiniGameZombieMovement zombieMovement)
		{
			_zombieAnimator = zombieAnimator;
			_zombieMovement = zombieMovement;
		}

		public override void OnEnter()
		{
			_zombieAnimator.PlayWalk();
		}

		public override void OnExit()
		{
			_zombieMovement.Stop();
		}

		public override string Name
		{
			get { return "Walk"; }
		}
	}
}
