using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
	public class HudParenter : MonoBehaviour
	{
		[Inject]
		private HudController _hud = null!;
		
		private void Awake()
		{
			transform.SetParent(_hud.transform);
		}
	}
}
