using _Project.Scripts.MiniGame;
using FSM;

namespace _Project.Scripts.Npc.States
{
	public class NpcIdleState : State
	{
		private readonly NpcAnimator _npcAnimator;
		private readonly IMiniGame _miniGame;

		public NpcIdleState(NpcAnimator npcAnimator, IMiniGame miniGame)
		{
			_npcAnimator = npcAnimator;
			_miniGame = miniGame;
		}

		public override void OnEnter()
		{
			_npcAnimator.PlayIdle();
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
