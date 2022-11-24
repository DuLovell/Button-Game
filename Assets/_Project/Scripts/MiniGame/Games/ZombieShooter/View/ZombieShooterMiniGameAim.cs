using System;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.View
{
	public class ZombieShooterMiniGameAim : MonoBehaviour
	{
		private RectTransform _rectTransform = null!;

		private float _xSpeed = 10f;
		private float _ySpeed = 10f;
		private const float SCREEN_WIDTH = 25.5f;
		private const float SCREEN_HEIGHT = 25.5f;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		private void Update()
		{
			Vector2 xDirection = _rectTransform.right * _xSpeed;
			Vector2 yDirection = _rectTransform.up * _ySpeed;
			Vector2 resultDirection = xDirection + yDirection;
			_rectTransform.anchoredPosition += resultDirection * Time.deltaTime;

			float aimHalfWidth = _rectTransform.sizeDelta.x / 2f;
			float aimHalfHeight = _rectTransform.sizeDelta.y / 2f;
			if (Position.x + aimHalfWidth >= SCREEN_WIDTH) {
				_xSpeed *= -1f;
				_rectTransform.anchoredPosition = new Vector2(SCREEN_WIDTH - aimHalfWidth, Position.y);
			} else if (Position.x - aimHalfWidth <= -SCREEN_WIDTH) {
				_xSpeed *= -1f;
				_rectTransform.anchoredPosition = new Vector2(-SCREEN_WIDTH + aimHalfWidth, Position.y);
			}
			if (Position.y + aimHalfHeight >= SCREEN_HEIGHT) {
				_ySpeed *= -1f;
				_rectTransform.anchoredPosition = new Vector2(Position.x, SCREEN_HEIGHT - aimHalfHeight);
			} else if (Position.y - aimHalfHeight <= -SCREEN_HEIGHT) {
				_ySpeed *= -1f;
				_rectTransform.anchoredPosition = new Vector2(Position.x, -SCREEN_HEIGHT + aimHalfHeight);
			}
		}

		private Vector2 Position
		{
			get
			{
				return _rectTransform.anchoredPosition;
			}
		}
	}
}
