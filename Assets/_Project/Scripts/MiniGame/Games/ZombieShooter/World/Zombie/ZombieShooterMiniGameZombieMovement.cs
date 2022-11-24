using System;
using _Project.Scripts.Services.Logger;
using Animancer;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.World.Zombie
{
	public class ZombieShooterMiniGameZombieMovement : MonoBehaviour
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<ZombieShooterMiniGameZombieMovement>();
		
		[SerializeField]
		private NavMeshAgent _agent = null!;
		
		private AnimancerComponent _animancerComponent = null!;

		private const float MOVEMENT_RADIUS = 10f;

		public void StartWalkingToRandomLocation()
		{
			_agent.isStopped = false;

			Vector3? location;
			do {
				location = GetRandomNavMeshLocation(MOVEMENT_RADIUS);
			} while (location == null && Vector3.Distance(ParentTransform.position, (Vector3) location!) > _agent.radius);
			
			StartWalking((Vector3) location);
		}

		public void StartWalking(Vector3 location)
		{
			_agent.isStopped = false;
			
			_agent.SetDestination(location);
		}

		public void Stop()
		{
			_agent.isStopped = true;
		}

		private void Awake()
		{
			_agent.updatePosition = false;
			_animancerComponent = GetComponent<AnimancerComponent>();
		}

		private void Update()
		{
			if (!IsWalking) {
				_agent.nextPosition = ParentTransform.position;
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
			randomDirection += ParentTransform.position;
			return NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, 1) 
					       ? hit.position 
					       : null;
		}

		private Transform ParentTransform
		{
			get { return transform.parent; }
		}

		public bool IsWalking
		{
			get
			{
				_logger.Debug($"Agent velocity magnitude={_agent.velocity.magnitude}");
				return _agent.velocity.magnitude > 0.2f && _agent.remainingDistance > _agent.radius;
			}
		}
	}
}
