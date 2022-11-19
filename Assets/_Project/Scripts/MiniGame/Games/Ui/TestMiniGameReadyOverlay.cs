using System;
using _Project.Scripts.MainButton;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.Ui
{
	public class TestMiniGameReadyOverlay : MonoBehaviour
	{
		[Inject]
		private MainButtonController _mainButtonController = null!;
		
		public async UniTask ShowAsync()
		{
			gameObject.SetActive(true);
			await UniTask.WaitUntil(_mainButtonController.IsButtonTouched);
			Hide();
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
		
		private void Awake()
		{
			Hide();
		}
	}
}
