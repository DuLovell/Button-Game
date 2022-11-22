using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.View
{
	// Не наследуется от View, т.к. нужен канвас в ScreenSpace, а не в Overlay
	public class ZombieShooterMiniGameView : MonoBehaviour, IMiniGameView
	{
		[SerializeField]
		private ZombieShooterMiniGameAimPanel _aimPanel = null!;
		
		private ZombieShooterMiniGameWorld _gameWorld = null!;

		public void DestroyView()
		{
			
		}

		private void Start()
		{
			_gameWorld = FindObjectOfType<ZombieShooterMiniGameWorld>();
			Canvas canvas = GetComponent<Canvas>();
			canvas.worldCamera = _gameWorld.TVScreenCamera;
		}
	}
}
