using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers
{
	public class UiInstaller : MonoInstaller
	{
		[SerializeField]
		private GameView _gameViewPrefab = null!;
		[SerializeField]
		private HudController _hud = null!;
		
		public override void InstallBindings()
		{
			Container.Bind<GameView>().FromComponentInNewPrefab(_gameViewPrefab).AsSingle();
			Container.Bind<HudController>().FromInstance(_hud).AsSingle();
		}
	}
}
