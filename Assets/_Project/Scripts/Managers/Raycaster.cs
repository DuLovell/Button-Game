using _Project.Scripts.Utilities;
using UnityEngine;
// ReSharper disable Unity.PreferNonAllocApi

namespace _Project.Scripts.Managers
{
	public class Raycaster : PersistentSingleton<Raycaster>
	{
		public static RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, string? layerMaskName = null)
		{
			Debugger.Instance.DrawRay(origin, direction, distance);
			return layerMaskName == null
					       ? Physics2D.RaycastAll(origin, direction, distance)
					       : Physics2D.RaycastAll(origin, direction, distance, LayerMask.GetMask(layerMaskName));
		}

		public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, string? layerMaskName = null)
		{
			Debugger.Instance.DrawRay(origin, direction, distance);
			return layerMaskName == null 
					       ? Physics2D.Raycast(origin, direction, distance) 
					       : Physics2D.Raycast(origin, direction, distance, LayerMask.GetMask(layerMaskName));
		}

		public static Collider2D[] OverlapPointAll(Vector2 point)
		{
			Collider2D[] hits = Physics2D.OverlapPointAll(point);
			Color debugColor = hits.Length > 0 
					                   ? Color.red 
					                   : Color.yellow;
			Debugger.Instance.DrawPoint(point, color: debugColor);
			return hits;
		}

		public static Collider2D[] OverlapBoxAll(Vector2 point, Vector2 size, float angle = 0f, string? layerMaskName = null)
		{
			Collider2D[] hits = layerMaskName == null 
					                    ? Physics2D.OverlapBoxAll(point, size, angle)
					                    : Physics2D.OverlapBoxAll(point, size, angle, LayerMask.GetMask(layerMaskName));
			Color debugColor = hits.Length > 0 
					                   ? Color.red 
					                   : Color.yellow;
			Debugger.Instance.DrawBox(point, size, angle, debugColor);
			return hits;
		}
	}
}
