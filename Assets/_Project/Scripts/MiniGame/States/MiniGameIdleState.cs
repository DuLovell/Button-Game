using FSM;

namespace _Project.Scripts.MiniGame.States
{
	public class MiniGameIdleState : State
	{
		private readonly MiniGameAnimator _miniGameAnimator;
		private readonly IMiniGame _miniGame;

		public MiniGameIdleState(MiniGameAnimator miniGameAnimator, IMiniGame miniGame)
		{
			_miniGameAnimator = miniGameAnimator;
			_miniGame = miniGame;
		}

		public override void OnEnter()
		{
			_miniGameAnimator.PlayIdle();
			_miniGame.StartGame();
		}

		public override void OnExit()
		{
			_miniGame.StopGame();
		}

		public override string Name
		{
			get { return "Idle"; }
		}
	}
}
