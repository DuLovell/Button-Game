using System.Collections;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameCube : MonoBehaviour
	{
		private float _directionModifier;
		
		public void StartRotating()
		{
			_directionModifier = 1f;
			StartCoroutine(RotatingRoutine());
		}

		public void InverseRotationDirection()
		{
			_directionModifier *= -1f;
		}

		private IEnumerator RotatingRoutine()
		{
			while (true) {
				transform.Rotate(_directionModifier * new Vector3(0f, 0.5f, 0f), Space.Self);
				yield return null;
			}
		}
	}
}
