using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services
{
	[UsedImplicitly]
	public class AssetProvider
	{
		[Inject]
		private DiContainer _diContainer = null!;

		public T CreateAsset<T>(Object prefab)
		{
			T instance = Object.Instantiate(prefab).GetComponent<T>();
			InjectSceneContext(instance);
			return instance;
		}

		private void InjectSceneContext<T>(T instance)
		{
			_diContainer.Inject(instance!);
		}
	}
}
