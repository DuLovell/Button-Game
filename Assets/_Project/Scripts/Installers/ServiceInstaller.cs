using _Project.Scripts.MiniGame;
using _Project.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class ServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private MiniGamesLauncher _miniGamesLauncherPrefab = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<AssetProvider>().AsSingle();
			Container.Bind<InputReader>().AsSingle();
			Container.Bind<MiniGamesLauncher>().FromComponentInNewPrefab(_miniGamesLauncherPrefab).AsSingle();
			Container.Bind<MiniGameFactory>().AsSingle();
		}
	}
}
