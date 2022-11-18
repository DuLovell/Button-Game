using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class UiInstaller : MonoInstaller
	{
		[SerializeField]
		private Canvas _hud = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<Canvas>().FromInstance(_hud);
		}
	}
}
