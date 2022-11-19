using _Project.Scripts.MiniGame.Games;
using _Project.Scripts.MiniGame.Games.Common;
using _Project.Scripts.MiniGame.Games.Ui;
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
		private TestMiniGameReadyOverlay _miniGameReadyOverlayPrefab = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<TestMiniGameDescriptor>().FromInstance(_miniGameDescriptor).AsSingle();
			Container.Bind<TestMiniGameModel>().AsSingle();
			Container.Bind<TestMiniGameLogic>().AsSingle();
			Container.Bind<TestMiniGameMediator>().AsSingle();
			Container.Bind<TestMiniGameView>().FromComponentInNewPrefab(_miniGameViewPrefab).AsTransient();
			Container.Bind<TestMiniGameReadyOverlay>().FromComponentInNewPrefab(_miniGameReadyOverlayPrefab).AsTransient();
		}
	}
}
