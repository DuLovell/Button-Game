using _Project.Scripts.MiniGame.States;
using FSM;

namespace _Project.Scripts.MiniGame
{
	public class MiniGameStateMachine : StateMachine
	{
		private MiniGameIdleState _idleState = null!;
		private MiniGameShowState _showState = null!;
		private MiniGameHideState _hideState = null!;

		private IMiniGame _miniGame = null!;
		private MiniGameAnimator _miniGameAnimator = null!;

		private void Awake()
		{
			_miniGameAnimator = GetComponent<MiniGameAnimator>();
			_miniGame = GetComponent<IMiniGame>();

			ConfigureStates();
			
			AddTransition(_showState, _idleState, _showState.OnShowAnimationEnded);
			AddTransition(_idleState, _hideState, () => _miniGame.CheckWin() || _miniGame.CheckLose());
		}

		private void Start()
		{
			SetState(_showState);
		}

		private void ConfigureStates()
		{
			_idleState = new MiniGameIdleState(_miniGameAnimator, _miniGame);
			_showState = new MiniGameShowState(_miniGameAnimator);
			_hideState = new MiniGameHideState(_miniGameAnimator);
		}
	}
}
