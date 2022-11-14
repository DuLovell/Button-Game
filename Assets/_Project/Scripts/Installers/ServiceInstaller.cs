using _Project.Scripts.Managers;
using _Project.Scripts.MiniGame;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class ServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<InputReader>().AsSingle();
			Container.Bind<MiniGameFactory>().AsSingle();
		}
	}
}
