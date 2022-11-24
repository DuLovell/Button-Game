using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.View
{
	public class ZombieShooterMiniGameAim : MonoBehaviour
	{
		private RectTransform _rectTransform = null!;

		private const float SCREEN_HEIGHT = 25.5f;
		private const float SCREEN_WIDTH = 25.5f;
		
		private float _xSpeed = 10f;
		private float _ySpeed = 10f;

		private float _aimHalfWidth;
		private float _aimHalfHeight;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_aimHalfWidth = _rectTransform.sizeDelta.x / 2f;
			_aimHalfHeight = _rectTransform.sizeDelta.y / 2f;
		}

		private void Update()
		{
			MoveInsideScreen();
		}

		private void MoveInsideScreen()
		{
			Vector2 resultDirection = _rectTransform.right * _xSpeed + _rectTransform.up * _ySpeed;
			AnchoredPosition += resultDirection * Time.deltaTime;

			if (AnchoredPosition.x + _aimHalfWidth >= SCREEN_WIDTH) {
				_xSpeed *= -1f;
				AnchoredPosition = new Vector2(SCREEN_WIDTH - _aimHalfWidth, AnchoredPosition.y);
			}
			else if (AnchoredPosition.x - _aimHalfWidth <= -SCREEN_WIDTH) {
				_xSpeed *= -1f;
				AnchoredPosition = new Vector2(-SCREEN_WIDTH + _aimHalfWidth, AnchoredPosition.y);
			}

			if (AnchoredPosition.y + _aimHalfHeight >= SCREEN_HEIGHT) {
				_ySpeed *= -1f;
				AnchoredPosition = new Vector2(AnchoredPosition.x, SCREEN_HEIGHT - _aimHalfHeight);
			}
			else if (AnchoredPosition.y - _aimHalfHeight <= -SCREEN_HEIGHT) {
				_ySpeed *= -1f;
				AnchoredPosition = new Vector2(AnchoredPosition.x, -SCREEN_HEIGHT + _aimHalfHeight);
			}
		}

		private Vector2 AnchoredPosition
		{
			get { return _rectTransform.anchoredPosition; }
			set { _rectTransform.anchoredPosition = value; }
		}
	}
}
