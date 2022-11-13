using FSM;

namespace _Project.Scripts.Npc.States
{
	public class NpcHideState : State
	{
		private readonly NpcAnimator _npcAnimator;

		public NpcHideState(NpcAnimator npcAnimator)
		{
			_npcAnimator = npcAnimator;
		}

		public override void OnEnter()
		{
			//TODO Проигрывать анимацию ухода
			_npcAnimator.PlayHide();
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
