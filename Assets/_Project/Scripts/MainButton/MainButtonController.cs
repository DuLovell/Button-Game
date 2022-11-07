using UnityEngine;

namespace _Project.Scripts.MainButton
{
	public class MainButtonController : MonoBehaviour
	{
		private MainButtonAnimator _mainButtonAnimator = null!;

		private void Awake()
		{
			_mainButtonAnimator = GetComponent<MainButtonAnimator>();
		}

		//TODO Сделать стейт машину, а то с анимациями уже проблема
		private void Update()
		{
			if (Input.touches.Length == 0) {
				return;
			}
			TouchPhase touchPhase = Input.GetTouch(0).phase;
			switch (touchPhase) {
				case TouchPhase.Began:
					_mainButtonAnimator.PlayPush();
					break;
				case TouchPhase.Ended or TouchPhase.Canceled:
					_mainButtonAnimator.PlayUnpush();
					break;
			}
		}
	}
}
