using _Project.Scripts.MainButton;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class WorldInstaller : MonoInstaller
	{
		[SerializeField]
		private MainButtonController _mainButtonController = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<MainButtonController>().FromInstance(_mainButtonController);
		}
	}
}
