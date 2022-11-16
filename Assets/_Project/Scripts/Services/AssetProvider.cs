using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services
{
	[UsedImplicitly]
	public class AssetProvider
	{
		private SceneContext? _sceneContext;

		public T CreateAsset<T>(Object prefab)
		{
			T instance = Object.Instantiate(prefab).GetComponent<T>();
			InjectSceneContext(instance);
			return instance;
		}

		private void InjectSceneContext<T>(T instance)
		{
			if (_sceneContext == null) {
				_sceneContext = Object.FindObjectOfType<SceneContext>();
			}
			_sceneContext.Container.Inject(instance!);
		}
	}
}
