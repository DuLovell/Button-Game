using Animancer;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
	public class ZombieShooterMiniGameZombieMovement : MonoBehaviour
	{
		[SerializeField]
		private NavMeshAgent _agent = null!;
		
		private AnimancerComponent _animancerComponent = null!;
		private ZombieShooterMiniGameWorld _gameWorld = null!;

		private const float MOVEMENT_RADIUS = 5f;
		private const int WALKABLE_AREA_MASK = 1;

		public bool IsWalking { get; private set; }

		public void StartWalkingToRandomLocation()
		{
			_agent.isStopped = false;

			Vector3? location;
			do {
				location = GetRandomNavMeshLocation(MOVEMENT_RADIUS);
				if (location != null && Vector3.Distance(ParentTransform.position, (Vector3) location) < _agent.radius) {
					location = null;
				}
			} while (location == null);
			
			StartWalking((Vector3) location);
		}

		public void StartWalking(Vector3 location)
		{
			_agent.isStopped = false;
			
			_agent.SetDestination(location);
			IsWalking = true;
		}

		public void Stop()
		{
			_agent.nextPosition = ParentTransform.position;
			_agent.isStopped = true;
			IsWalking = false;
		}

		private void Awake()
		{
			_agent.updatePosition = false;
			_animancerComponent = GetComponent<AnimancerComponent>();
		}

		private void Start()
		{
			_gameWorld = FindObjectOfType<ZombieShooterMiniGameWorld>();
		}

		private void Update()
		{
			if (IsWalking && _agent.remainingDistance < _agent.radius) {
				Stop();
			}
			if (!IsWalking) {
				return;
			}
			Vector3 worldDeltaPosition = _agent.nextPosition - ParentTransform.position;
			if (worldDeltaPosition.magnitude > _agent.radius) {
				_agent.nextPosition = ParentTransform.position + 0.9f * worldDeltaPosition;
			}
		}

		private void OnAnimatorMove() {
			Vector3 position = _animancerComponent.Animator.rootPosition;
			position.y = _agent.nextPosition.y;
			ParentTransform.position = position;
		}

		private Vector3? GetRandomNavMeshLocation(float radius) 
		{
			Vector3 randomDirection = Random.insideUnitSphere * radius;
			randomDirection += _gameWorld.WalkingPlaneTransform.position;
			return NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, WALKABLE_AREA_MASK) 
					       ? hit.position 
					       : null;
		}

		private Transform ParentTransform
		{
			get { return transform.parent; }
		}
	}
}
