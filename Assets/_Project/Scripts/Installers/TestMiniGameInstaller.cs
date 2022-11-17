using _Project.Scripts.MiniGame.Games;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class TestMiniGameInstaller : MonoInstaller
	{
		[SerializeField]
		private TestMiniGameDescriptor _miniGameDescriptor = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<TestMiniGameDescriptor>().FromInstance(_miniGameDescriptor).AsSingle();
			Container.Bind<TestMiniGameWorld>().AsSingle();
			Container.Bind<TestMiniGameLogic>().AsSingle();
			Container.Bind<TestMiniGameMediator>().AsSingle();
		}
	}
}
