using _Project.Scripts.MiniGame.Games.ZombieShooter.Descriptor;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.View
{
	public class ZombieShooterMiniGameAim : MonoBehaviour
	{
		[Inject] 
		private ZombieShooterMiniGameDescriptor _gameDescriptor = null!;

		private RectTransform _rectTransform = null!;

		private float _aimHalfWidth;
		private float _aimHalfHeight;
		private float _screenWidth;
		private float _screenHeight;
		
		private float _xSpeed;
		private float _ySpeed;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_aimHalfWidth = _rectTransform.sizeDelta.x / 2f;
			_aimHalfHeight = _rectTransform.sizeDelta.y / 2f;

			_screenWidth = _gameDescriptor.TVScreenWidth;
			_screenHeight = _gameDescriptor.TVScreenHeight;
			
			_xSpeed = _gameDescriptor.StartAimMoveSpeed;
			_ySpeed = _gameDescriptor.StartAimMoveSpeed;
		}

		private void Update()
		{
			MoveInsideScreen();
		}

		private void MoveInsideScreen()
		{
			Vector2 resultDirection = _rectTransform.right * _xSpeed + _rectTransform.up * _ySpeed;
			AnchoredPosition += resultDirection * Time.deltaTime;

			if (AnchoredPosition.x + _aimHalfWidth >= _screenWidth) {
				_xSpeed *= -1f;
				AnchoredPosition = new Vector2(_screenWidth - _aimHalfWidth, AnchoredPosition.y);
			}
			else if (AnchoredPosition.x - _aimHalfWidth <= -_screenWidth) {
				_xSpeed *= -1f;
				AnchoredPosition = new Vector2(-_screenWidth + _aimHalfWidth, AnchoredPosition.y);
			}

			if (AnchoredPosition.y + _aimHalfHeight >= _screenHeight) {
				_ySpeed *= -1f;
				AnchoredPosition = new Vector2(AnchoredPosition.x, _screenHeight - _aimHalfHeight);
			}
			else if (AnchoredPosition.y - _aimHalfHeight <= -_screenHeight) {
				_ySpeed *= -1f;
				AnchoredPosition = new Vector2(AnchoredPosition.x, -_screenHeight + _aimHalfHeight);
			}
		}

		private Vector2 AnchoredPosition
		{
			get { return _rectTransform.anchoredPosition; }
			set { _rectTransform.anchoredPosition = value; }
		}
	}
}
