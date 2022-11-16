using _Project.Scripts.MiniGame.Games;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class TestMiniGameInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<TestMiniGameWorld>().AsSingle();
			Container.Bind<TestMiniGameLogic>().AsSingle();
			Container.Bind<TestMiniGameMediator>().AsSingle();
		}
	}
}
