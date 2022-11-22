using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
	public class ZombieShooterMiniGameZombieMovement : MonoBehaviour
	{
		private const float MOVEMENT_RADIUS = 3f;

		private NavMeshAgent _navMeshAgent = null!;
		
		public void StartWalkingToRandomLocation()
		{
			Vector3? location;
			do {
				location = GetRandomNavMeshLocation(MOVEMENT_RADIUS);
			} while (location == null);
			
			StartWalking((Vector3) location);
		}

		public void StartWalking(Vector3 location)
		{
			_navMeshAgent.SetDestination(location);
		}

		public void Stop()
		{
			_navMeshAgent.isStopped = true;
		}

		private void Awake()
		{
			_navMeshAgent = GetComponent<NavMeshAgent>();
		}

		private Vector3? GetRandomNavMeshLocation(float radius) 
		{
			Vector3 randomDirection = Random.insideUnitSphere * radius;
			randomDirection += transform.position;
			return NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, 1) 
					       ? hit.position 
					       : null;
		}

		public bool IsWalking
		{
			get { return _navMeshAgent.velocity.sqrMagnitude > float.Epsilon; }
		}
	}
}
