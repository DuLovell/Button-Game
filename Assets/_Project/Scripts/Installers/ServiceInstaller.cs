using _Project.Scripts.Managers;
using _Project.Scripts.Npc;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class ServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<InputReader>().AsSingle();
			Container.Bind<NpcFactory>().AsSingle();
		}
	}
}
