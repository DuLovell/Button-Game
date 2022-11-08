using _Project.Scripts.Managers.Logger;
using _Project.Scripts.Utilities;
using UnityEngine;
// ReSharper disable Unity.PreferNonAllocApi

namespace _Project.Scripts.Managers
{
	public class Debugger : Singleton<Debugger>
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<Debugger>();

		[SerializeField] private float _rayVisibilityDurationSeconds = 1f;

		public void DrawPoint(Vector2 point, float radius = 0.1f, Color? color = null)
		{
			Color rayColor = color ?? Color.yellow;

			DrawRay(point, Vector3.up, radius, rayColor);
			DrawRay(point, Vector3.down, radius, rayColor);
			DrawRay(point, Vector3.left, radius, rayColor);
			DrawRay(point, Vector3.right, radius, rayColor);
			
			DrawRay(point, Vector3.up + Vector3.right, radius, rayColor);
			DrawRay(point, Vector3.up + Vector3.left, radius, rayColor);
			DrawRay(point, Vector3.down + Vector3.right, radius, rayColor);
			DrawRay(point, Vector3.down + Vector3.left, radius, rayColor);
		}

		// https://www.reddit.com/r/Unity2D/comments/d9arky/help_needed_overlapbox_rotation/
		public void DrawBox(Vector2 point, Vector2 size, float angle, Color color)
		{
			Quaternion orientation = Quaternion.Euler(0, 0, angle);

			// Basis vectors, half the size in each direction from the center.
			Vector2 right = orientation * Vector2.right * size.x / 2f;
			Vector2 up = orientation * Vector2.up * size.y / 2f;

			// Four box corners.
			Vector2 topLeft = point + up - right;
			Vector2 topRight = point + up + right;
			Vector2 bottomRight = point - up + right;
			Vector2 bottomLeft = point - up - right;

			// Now we've reduced the problem to drawing lines.
			DrawLine(topLeft, topRight, color);
			DrawLine(topRight, bottomRight, color);
			DrawLine(bottomRight, bottomLeft, color);
			DrawLine(bottomLeft, topLeft, color);
		}
		
		public void DrawRay(Vector2 origin, Vector2 direction, float distance, Color? color = null)
		{
			Color rayColor = color ?? Color.red;
			Debug.DrawRay(origin, direction.normalized * distance, rayColor, _rayVisibilityDurationSeconds);
		}
		
		public void DrawLine(Vector2 start, Vector2 end, Color? color = null)
		{
			Color lineColor = color ?? Color.red;
			Debug.DrawLine(start, end, lineColor, _rayVisibilityDurationSeconds);
		}
	}
}
