
using _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie.StateMachine.States;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie.StateMachine
{
	public class ZombieShooterMiniGameZombieStateMachine : FSM.StateMachine
	{
		private ZombieShooterMiniGameZombieAnimator _zombieAnimator = null!;
		private ZombieShooterMiniGameZombieMovement _zombieMovement = null!;

		private ZombieShooterMiniGameZombieIdleState _idleState = null!;
		private ZombieShooterMiniGameZombieWalkState _walkState = null!;
		private ZombieShooterMiniGameZombieDeadState _deadState = null!;

		private void Awake()
		{
			_zombieAnimator = GetComponentInChildren<ZombieShooterMiniGameZombieAnimator>();
			_zombieMovement = GetComponentInChildren<ZombieShooterMiniGameZombieMovement>();

			ConfigureStates();
			
			AddTransition(_idleState, _walkState, () => _zombieMovement.IsWalking);
			AddTransition(_walkState, _idleState, () => !_zombieMovement.IsWalking);
			
			ZombieShooterMiniGameZombie zombie = GetComponent<ZombieShooterMiniGameZombie>();
			AddAnyTransition(_deadState, () => zombie.IsKilled);
		}

		private void Start()
		{
			SetState(_idleState); // Переходим в дефолтное состояние
		}

		private void ConfigureStates()
		{
			_idleState = new ZombieShooterMiniGameZombieIdleState(_zombieAnimator, _zombieMovement);
			_walkState = new ZombieShooterMiniGameZombieWalkState(_zombieAnimator, _zombieMovement);
			_deadState = new ZombieShooterMiniGameZombieDeadState(_zombieAnimator, _zombieMovement);
		}
	}
}
