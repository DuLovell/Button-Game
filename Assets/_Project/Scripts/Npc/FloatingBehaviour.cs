using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Npc
{
	public class FloatingBehaviour : MonoBehaviour
	{
		private const float MOVE_RANGE = 0.05f;
		private const float MOVE_DURATION = 1;

		private Vector3 _velocity = Vector3.zero;
		private float _directionModifier = 1;

		private void Awake()
		{
			StartCoroutine(FloatingRoutine());
		}

		private IEnumerator FloatingRoutine()
		{
			Vector3 centralPoint = transform.position;

			while (true) {
				_velocity = Vector3.zero;
				Vector3 targetPosition = new(centralPoint.x, centralPoint.y + (_directionModifier * MOVE_RANGE), centralPoint.z);
				while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
				{
					transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, MOVE_DURATION);
					yield return null;
				}
				_directionModifier *= -1;
			}
			// ReSharper disable once IteratorNeverReturns
		}
	}
}
