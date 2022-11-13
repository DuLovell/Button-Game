using FSM;

namespace _Project.Scripts.Npc.States
{
	public class NpcIdleState : State
	{
		private readonly NpcAnimator _npcAnimator;

		public NpcIdleState(NpcAnimator npcAnimator)
		{
			_npcAnimator = npcAnimator;
		}

		public override void OnEnter()
		{
			_npcAnimator.PlayIdle();
		}

		public override void OnExit()
		{
		}

		public override string Name
		{
			get { return "Idle"; }
		}
	}
}
