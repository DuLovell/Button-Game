using FSM;

namespace _Project.Scripts.MiniGame.States
{
	public class MiniGameHideState : State
	{
		private readonly MiniGameAnimator _miniGameAnimator;

		public MiniGameHideState(MiniGameAnimator miniGameAnimator)
		{
			_miniGameAnimator = miniGameAnimator;
		}

		public override void OnEnter()
		{
			//TODO Проигрывать анимацию ухода
			_miniGameAnimator.PlayHide();
		}

		public override void OnExit()
		{
		}

		public override string Name
		{
			get { return "Hide"; }
		}
	}
}
