using UnityEngine;

namespace _Project.Scripts.Utilities
{
	public static class Helpers
	{
		public static Vector2 GetRandomPointOnUnitCircle(float radius)
		{
			float angle = Random.Range(0f, Mathf.PI * 2);
			float x = Mathf.Sin(angle) * radius;
			float y = Mathf.Cos(angle) * radius;
			return new Vector2(x, y);
		}
	}
}
