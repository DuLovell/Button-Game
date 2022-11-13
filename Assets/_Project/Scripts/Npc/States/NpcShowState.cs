using FSM;

namespace _Project.Scripts.Npc.States
{
	public class NpcShowState : State
	{
		public readonly EventObject OnShowAnimationEnded = new();
		
		private readonly NpcAnimator _npcAnimator;

		public NpcShowState(NpcAnimator npcAnimator)
		{
			_npcAnimator = npcAnimator;
		}

		public override void OnEnter()
		{
			//TODO Проигрывать анимацию показа
			_npcAnimator.PlayShow();
			OnShowAnimationEnded.Invoke();
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
