using _Project.Scripts.Npc.States;
using FSM;

namespace _Project.Scripts.Npc
{
	public class NpcStateMachine : StateMachine
	{
		private NpcIdleState _idleState = null!;
		private NpcExplodeState _explodeState = null!;
		private NpcShowState _showState = null!;
		private NpcHideState _hideState = null!;

		private IMiniGame _miniGame = null!;
		private NpcAnimator _npcAnimator = null!;

		private void Awake()
		{
			_npcAnimator = GetComponent<NpcAnimator>();
			_miniGame = GetComponent<IMiniGame>();

			ConfigureStates();
			
			AddTransition(_showState, _idleState, _showState.OnShowAnimationEnded);
			AddTransition(_idleState, _hideState, () => _miniGame.CheckWin() || _miniGame.CheckLose());
			AddTransition(_idleState, _explodeState, _miniGame.CheckExplosion);
		}

		private void Start()
		{
			SetState(_showState);
		}

		private void ConfigureStates()
		{
			_idleState = new NpcIdleState(_npcAnimator, _miniGame);
			_showState = new NpcShowState(_npcAnimator);
			_hideState = new NpcHideState(_npcAnimator);
			_explodeState = new NpcExplodeState(_npcAnimator);
		}
	}
}
