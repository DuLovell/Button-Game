using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Controller;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Descriptor;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Logic;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Mediator;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Model;
using _Project.Scripts.MiniGame.Games.ZombieShooter.View;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class ZombieShooterMiniGameInstaller : MonoInstaller
	{
		[SerializeField]
		private ZombieShooterMiniGameDescriptor _miniGameDescriptor = null!;
		[SerializeField]
		private ZombieShooterMiniGameView _miniGameViewPrefab = null!;
		[SerializeField]
		private ReadyOverlay _miniGameReadyOverlayPrefab = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<ZombieShooterMiniGameDescriptor>().FromInstance(_miniGameDescriptor).AsSingle();
			
			Container.Bind<ZombieShooterMiniGameModel>().AsSingle();
			Container.Bind<IMiniGameModel>().To<ZombieShooterMiniGameModel>().FromResolve().WhenInjectedInto<ZombieShooterMiniGameController>();
			
			Container.Bind<ZombieShooterMiniGameLogic>().AsSingle();
			Container.Bind<IMiniGameLogic>().To<ZombieShooterMiniGameLogic>().FromResolve().WhenInjectedInto<ZombieShooterMiniGameController>();

			Container.Bind<ZombieShooterMiniGameMediator>().AsSingle();
			Container.Bind<IMiniGameMediator>().To<ZombieShooterMiniGameMediator>().FromResolve().WhenInjectedInto<ZombieShooterMiniGameController>();

			Container.Bind<ZombieShooterMiniGameView>().FromComponentInNewPrefab(_miniGameViewPrefab).AsTransient();
			Container.Bind<IMiniGameView>().To<ZombieShooterMiniGameView>().FromResolve().WhenInjectedInto<ZombieShooterMiniGameController>();
		}
	}
}
