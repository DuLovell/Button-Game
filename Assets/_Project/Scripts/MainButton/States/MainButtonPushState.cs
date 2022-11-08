using _Project.Scripts.FSM;

namespace _Project.Scripts.MainButton.States
{
    public class MainButtonPushState : State
    {
        private readonly MainButtonAnimator _mainButtonAnimator;

        public MainButtonPushState(MainButtonAnimator mainButtonAnimator)
        {
            _mainButtonAnimator = mainButtonAnimator;
        }

        public override void OnEnter()
        {
            _mainButtonAnimator.PlayPush();
        }

        public override void OnExit()
        {
        }

        public override string Name
        {
            get { return "Push"; }
        }
    }
}