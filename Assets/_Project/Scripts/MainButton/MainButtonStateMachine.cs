using _Project.Scripts.FSM;
using _Project.Scripts.MainButton.States;
using _Project.Scripts.Managers;

namespace _Project.Scripts.MainButton
{
    public class MainButtonStateMachine : StateMachine
    {
        private MainButtonAnimator _mainButtonAnimator = null!;

        private MainButtonPushState _pushState = null!;
        private MainButtonUnpushState _unpushState = null!;

        private void Awake()
        {
            _mainButtonAnimator = GetComponent<MainButtonAnimator>();

            ConfigureStates();
			
            AddTransition(_unpushState, _pushState, InputReader.Instance.OnTouchBegan);
            AddTransition(_pushState, _unpushState, InputReader.Instance.OnTouchEnded);
        }

        private void Start()
        {
            SetState(_unpushState);
        }

        private void ConfigureStates()
        {
            _pushState = new MainButtonPushState(_mainButtonAnimator);
            _unpushState = new MainButtonUnpushState(_mainButtonAnimator);
        }
    }
}