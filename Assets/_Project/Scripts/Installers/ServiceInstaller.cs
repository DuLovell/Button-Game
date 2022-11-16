using _Project.Scripts.MiniGame;
using _Project.Scripts.Services;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class ServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<AssetProvider>().AsSingle();
			Container.Bind<InputReader>().AsSingle();
			Container.Bind<MiniGameFactory>().AsSingle();
		}
	}
}
