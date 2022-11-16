using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace _Project.Scripts.Services
{
	[UsedImplicitly]
	public class AssetProvider
	{
		public T CreateAsset<T>(Object prefab)
		{
			return Object.Instantiate(prefab).GetComponent<T>();
		}
	}
}
