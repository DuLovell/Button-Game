using System;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Model;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.View
{
	public class ZombieShooterMiniGameAimPanel : MonoBehaviour
	{
		[SerializeField]
		private Image _aim = null!;
		[Inject]
		private ZombieShooterMiniGameModel _gameModel = null!;
		
		private ZombieShooterMiniGameWorld _gameWorld = null!;

		private void Start()
		{
			_gameWorld = FindObjectOfType<ZombieShooterMiniGameWorld>();
		}

		private void Update()
		{
			_gameModel.AimPosition = AimPosition;
		}

		public Vector3 AimPosition
		{
			get
			{
				return _gameWorld.TVScreenCamera.WorldToScreenPoint(_aim.rectTransform.position);
			}
		}
	}
}
