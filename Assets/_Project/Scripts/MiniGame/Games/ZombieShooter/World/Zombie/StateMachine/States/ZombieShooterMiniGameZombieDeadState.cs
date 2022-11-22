using FSM;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie.StateMachine.States
{
	public class ZombieShooterMiniGameZombieDeadState : State
	{
		private readonly ZombieShooterMiniGameZombieAnimator _zombieAnimator;
		private readonly ZombieShooterMiniGameZombieMovement _zombieMovement;

		public ZombieShooterMiniGameZombieDeadState(ZombieShooterMiniGameZombieAnimator zombieAnimator,
		                                            ZombieShooterMiniGameZombieMovement zombieMovement)
		{
			_zombieAnimator = zombieAnimator;
			_zombieMovement = zombieMovement;
		}

		public override void OnEnter()
		{
			_zombieMovement.Stop();
			_zombieAnimator.PlayDeath();
		}

		public override void OnExit()
		{
		}

		public override string Name
		{
			get { return "Dead"; }
		}
	}
}
