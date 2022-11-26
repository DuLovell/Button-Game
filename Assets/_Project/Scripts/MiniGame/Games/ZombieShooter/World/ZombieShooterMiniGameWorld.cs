using System;
using System.Collections.Generic;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Descriptor;
using _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie;
using _Project.Scripts.Services;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World
{
	public class ZombieShooterMiniGameWorld : MonoBehaviour
	{
		[SerializeField] 
		private Transform _zombieSpawnPoint = null!;
		[SerializeField] 
		private Transform _locationTransform = null!;
		[Inject] 
		private ZombieShooterMiniGameDescriptor _gameDescriptor = null!;
		[Inject] 
		private AssetProvider _assetProvider = null!;
		
		[field: SerializeField]
		public Camera TVScreenCamera { get; private set; } = null!;
		[field: SerializeField]
		public List<ZombieShooterMiniGameZombie> Zombies { get; private set; } = new();
		[field: SerializeField]
		public Transform WalkingPlaneTransform { get; private set; } = null!;

		//TODO Заспавнить зомби в указанной области
		public void SpawnZombies()
		{
			for (int i = 0; i < _gameDescriptor.InRoomZombieCount; i++) {
				ZombieShooterMiniGameZombie zombie = _assetProvider.CreateAsset<ZombieShooterMiniGameZombie>(_gameDescriptor.ZombiePrefab);
				Zombies.Add(zombie);
				NavMeshAgent zombieAgent = zombie.GetComponent<NavMeshAgent>();
				zombieAgent.enabled = false;
				zombie.transform.SetParent(_locationTransform);
				zombie.transform.localPosition = _zombieSpawnPoint.localPosition;
				zombieAgent.enabled = true;
				
				zombie.GetComponentInChildren<ZombieShooterMiniGameZombieMovement>().StartWalkingToRandomLocation();
			}
		}
	}
}
