using System;
using _Project.Scripts.Services;
using FSM;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MainButton
{
	public class MainButtonController : MonoBehaviour
	{
		private const string MAIN_BUTTON_LAYER_NAME = "MainButton";

		[Inject]
		private InputReader _inputReader = null!;
		
		public readonly EventObject OnButtonTouched = new();
		public readonly EventObject OnButtonUntouched = new();

		private bool _isTouched;

		public bool IsButtonTouched()
		{
			if (!_inputReader.TryGetTouch(out Touch touch)) {
				return false;
			}
            
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			return Physics.Raycast(ray, Mathf.Infinity, LayerMask.GetMask(MAIN_BUTTON_LAYER_NAME));
		}

		private void Update()
		{
			if (!_isTouched && IsButtonTouched()) {
				OnButtonTouched.Invoke();
				_isTouched = true;
			} else if (_isTouched && !IsButtonTouched()) {
				OnButtonUntouched.Invoke();
				_isTouched = false;
			}
		}
	}
}
