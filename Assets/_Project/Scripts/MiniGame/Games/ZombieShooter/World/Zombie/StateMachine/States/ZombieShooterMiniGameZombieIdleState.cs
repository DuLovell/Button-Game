using System;
using Cysharp.Threading.Tasks;
using FSM;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie.StateMachine.States
{
	public class ZombieShooterMiniGameZombieIdleState : State
	{
		private const float BEFORE_MOVE_MIN_DELAY = 3f;
		private const float BEFORE_MOVE_MAX_DELAY = 10f;
		
		private readonly ZombieShooterMiniGameZombieAnimator _zombieAnimator;
		private readonly ZombieShooterMiniGameZombieMovement _zombieMovement;

		public ZombieShooterMiniGameZombieIdleState(ZombieShooterMiniGameZombieAnimator zombieAnimator,
		                                            ZombieShooterMiniGameZombieMovement zombieMovement)
		{
			_zombieAnimator = zombieAnimator;
			_zombieMovement = zombieMovement;
		}

		public override void OnEnter()
		{
			_zombieAnimator.PlayIdle();
			MoveToRandomLocationAfterDelay().Forget();
		}

		public override void OnExit()
		{
		}

		public override string Name
		{
			get { return "Idle"; }
		}

		private async UniTaskVoid MoveToRandomLocationAfterDelay()
		{
			await UniTask.Delay(TimeSpan.FromSeconds(Random.Range(BEFORE_MOVE_MIN_DELAY, BEFORE_MOVE_MAX_DELAY)), DelayType.DeltaTime);
			_zombieMovement.StartWalkingToRandomLocation();
		}
	}
}
