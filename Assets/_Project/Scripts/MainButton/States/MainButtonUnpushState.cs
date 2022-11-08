using System.Diagnostics.CodeAnalysis;
using _Project.Scripts.FSM;

namespace _Project.Scripts.MainButton.States
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class MainButtonUnpushState : State
    {
        private readonly MainButtonAnimator _mainButtonAnimator;

        public MainButtonUnpushState(MainButtonAnimator mainButtonAnimator)
        {
            _mainButtonAnimator = mainButtonAnimator;
        }
        
        public override void OnEnter()
        {
            _mainButtonAnimator.PlayUnpush();
        }

        public override void OnExit()
        {
        }

        public override string Name
        {
            get { return "Unpush"; }
        }
    }
}