using System.Collections;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameCube : MonoBehaviour
	{
		private Coroutine _rotateCoroutine = null!;
		
		private float _directionModifier;

		public void StartRotating()
		{
			_directionModifier = 1f;
			_rotateCoroutine = StartCoroutine(RotatingRoutine());
		}

		public void StopRotating()
		{
			StopCoroutine(_rotateCoroutine);
		}

		public void InverseRotationDirection()
		{
			_directionModifier *= -1f;
		}

		private IEnumerator RotatingRoutine()
		{
			while (true) {
				transform.Rotate(_directionModifier * new Vector3(0f, 100f, 0f) * Time.deltaTime, Space.Self);
				yield return null;
			}
		}
	}
}
