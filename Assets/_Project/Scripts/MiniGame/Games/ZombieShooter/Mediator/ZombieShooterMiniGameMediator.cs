using _Project.Scripts.MainButton;
using _Project.Scripts.MiniGame.Common;
using _Project.Scripts.MiniGame.Games.ZombieShooter.Logic;
using JetBrains.Annotations;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.ZombieShooter.Mediator
{
	[UsedImplicitly]
	public class ZombieShooterMiniGameMediator : IMiniGameMediator
	{
		[Inject]
		private MainButtonController _mainButtonController = null!;
		[Inject]
		private ZombieShooterMiniGameLogic _gameLogic = null!;

		public void Activate()
		{
			_mainButtonController.OnButtonTouched.Event += _gameLogic.OnMainButtonPressed;
		}

		public void Deactivate()
		{
			_mainButtonController.OnButtonTouched.Event -= _gameLogic.OnMainButtonPressed;
		}
	}
}
