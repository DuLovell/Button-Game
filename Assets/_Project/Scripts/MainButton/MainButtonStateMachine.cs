using _Project.Scripts.MainButton.Data;
using _Project.Scripts.MainButton.States;
using _Project.Scripts.Managers;
using FSM;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MainButton
{
    public class MainButtonStateMachine : StateMachine
    {
        private const string MAIN_BUTTON_LAYER_NAME = "MainButton";
        
        [Inject]
        private InputReader _inputReader = null!;
        [Inject]
        private MainButtonModel _model = null!;
        
        private MainButtonAnimator _mainButtonAnimator = null!;

        private MainButtonPushState _pushState = null!;
        private MainButtonUnpushState _unpushState = null!;

        private void Awake()
        {
            _mainButtonAnimator = GetComponent<MainButtonAnimator>();

            ConfigureStates();
			
            AddTransition(_unpushState, _pushState, IsButtonTouched);
            AddTransition(_pushState, _unpushState, () => !IsButtonTouched());
        }

        private void Start()
        {
            SetState(_unpushState);
        }

        private void ConfigureStates()
        {
            _pushState = new MainButtonPushState(_mainButtonAnimator, _model);
            _unpushState = new MainButtonUnpushState(_mainButtonAnimator);
        }

        private bool IsButtonTouched()
        {
            if (!_inputReader.TryGetTouch(out Touch touch)) {
                return false;
            }
            
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            return Physics.Raycast(ray, Mathf.Infinity, LayerMask.GetMask(MAIN_BUTTON_LAYER_NAME));
        }
    }
}
