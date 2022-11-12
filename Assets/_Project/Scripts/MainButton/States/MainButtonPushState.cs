using _Project.Scripts.MainButton.Data;
using FSM;

namespace _Project.Scripts.MainButton.States
{
    public class MainButtonPushState : State
    {
        private readonly MainButtonAnimator _mainButtonAnimator;
        private readonly MainButtonModel _mainButtonModel;

        public MainButtonPushState(MainButtonAnimator mainButtonAnimator, MainButtonModel mainButtonModel)
        {
            _mainButtonAnimator = mainButtonAnimator;
            _mainButtonModel = mainButtonModel;
        }

        public override void OnEnter()
        {
            _mainButtonAnimator.PlayPush();
            _mainButtonModel.PushCount++;
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
