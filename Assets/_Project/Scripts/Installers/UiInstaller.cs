using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class UiInstaller : MonoInstaller
	{
		[SerializeField]
		private Canvas _hudPrefab = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<Canvas>().FromComponentInNewPrefab(_hudPrefab).AsSingle();
		}
	}
}
