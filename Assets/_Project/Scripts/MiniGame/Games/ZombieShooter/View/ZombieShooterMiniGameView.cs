using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Logic;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.View
{
	// Не наследуется от View, т.к. нужен канвас в ScreenSpace, а не в Overlay
	public class ZombieShooterMiniGameView : MonoBehaviour, IMiniGameView
	{
		[SerializeField]
		private ZombieShooterMiniGameAimPanel _aimPanel = null!;
		[Inject] 
		private ZombieShooterMiniGameLogic _gameLogic = null!;

		private ZombieShooterMiniGameWorld _gameWorld = null!;

		public void DestroyView()
		{
			Destroy(gameObject);
		}

		private void Awake()
		{
			_aimPanel.Hide();
		}

		private void OnEnable()
		{
			_gameLogic.OnGameStarted += OnGameStarted;
		}

		private void OnDisable()
		{
			_gameLogic.OnGameStarted -= OnGameStarted;
		}

		private void Start()
		{
			_gameWorld = FindObjectOfType<ZombieShooterMiniGameWorld>();
			Canvas canvas = GetComponent<Canvas>();
			canvas.worldCamera = _gameWorld.TVScreenCamera;
		}

		private void OnGameStarted()
		{
			_aimPanel.Show();
		}
	}
}
