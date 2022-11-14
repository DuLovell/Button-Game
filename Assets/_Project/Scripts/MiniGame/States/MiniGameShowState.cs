using FSM;

namespace _Project.Scripts.MiniGame.States
{
	public class MiniGameShowState : State
	{
		public readonly EventObject OnShowAnimationEnded = new();
		
		private readonly MiniGameAnimator _miniGameAnimator;

		public MiniGameShowState(MiniGameAnimator miniGameAnimator)
		{
			_miniGameAnimator = miniGameAnimator;
		}

		public override void OnEnter()
		{
			_miniGameAnimator.PlayShow(() => OnShowAnimationEnded.Invoke());
		}

		public override void OnExit()
		{
		}

		public override string Name
		{
			get { return "Show"; }
		}
	}
}
