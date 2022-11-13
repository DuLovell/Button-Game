using FSM;

namespace _Project.Scripts.Npc.States
{
	public class NpcExplodeState : State
	{
		private readonly NpcAnimator _npcAnimator;

		public NpcExplodeState(NpcAnimator npcAnimator)
		{
			_npcAnimator = npcAnimator;
		}

		public override void OnEnter()
		{
			//TODO Проигрывать анимацию взрыва
			_npcAnimator.PlayExplode();
		}

		public override void OnExit()
		{
		}

		public override string Name
		{
			get { return "Explode"; }
		}
	}
}
