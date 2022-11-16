using System;
using _Project.Scripts.MainButton.Data;
using _Project.Scripts.MainButton.States;
using _Project.Scripts.Services;
using FSM;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MainButton
{
    public class MainButtonStateMachine : StateMachine
    {
        [Inject]
        private MainButtonModel _model = null!;

        private MainButtonController _mainButtonController = null!;
        private MainButtonAnimator _mainButtonAnimator = null!;

        private MainButtonPushState _pushState = null!;
        private MainButtonUnpushState _unpushState = null!;

        private void Awake()
        {
            _mainButtonController = GetComponent<MainButtonController>();
            _mainButtonAnimator = GetComponent<MainButtonAnimator>();

            ConfigureStates();
			
            AddTransition(_unpushState, _pushState, _mainButtonController.OnButtonTouched);
            AddTransition(_pushState, _unpushState, _mainButtonController.OnButtonUntouched);
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
    }
}
