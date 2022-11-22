using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games;
using _Project.Scripts.MiniGame.Games.Test;
using _Project.Scripts.MiniGame.Games.Test.Model;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class TestMiniGameInstaller : MonoInstaller
	{
		[SerializeField]
		private TestMiniGameDescriptor _miniGameDescriptor = null!;
		[SerializeField]
		private TestMiniGameView _miniGameViewPrefab = null!;
		[SerializeField]
		private ReadyOverlay _miniGameReadyOverlayPrefab = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<TestMiniGameDescriptor>().FromInstance(_miniGameDescriptor).AsSingle();
			
			Container.Bind<TestMiniGameModel>().AsSingle();
			Container.Bind<IMiniGameModel>().To<TestMiniGameModel>().FromResolve().WhenInjectedInto<TestMiniGameController>();
			
			Container.Bind<TestMiniGameLogic>().AsSingle();
			Container.Bind<IMiniGameLogic>().To<TestMiniGameLogic>().FromResolve().WhenInjectedInto<TestMiniGameController>();

			Container.Bind<TestMiniGameMediator>().AsSingle();
			Container.Bind<IMiniGameMediator>().To<TestMiniGameMediator>().FromResolve().WhenInjectedInto<TestMiniGameController>();

			Container.Bind<TestMiniGameView>().FromComponentInNewPrefab(_miniGameViewPrefab).AsTransient();
			Container.Bind<IMiniGameView>().To<TestMiniGameView>().FromResolve().WhenInjectedInto<TestMiniGameController>();

			Container.Bind<ReadyOverlay>().FromComponentInNewPrefab(_miniGameReadyOverlayPrefab).AsTransient();
		}
	}
}
