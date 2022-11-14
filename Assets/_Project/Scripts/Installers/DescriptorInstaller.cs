using _Project.Scripts.MiniGame.Data;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class DescriptorInstaller : MonoInstaller
	{
		[SerializeField]
		private MiniGamesLauncherDescriptor _miniGamesLauncherDescriptor = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<MiniGamesLauncherDescriptor>().FromInstance(_miniGamesLauncherDescriptor);
		}
	}
}
