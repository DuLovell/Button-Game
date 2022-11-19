using _Project.Scripts.MainButton;
using _Project.Scripts.MiniGame.Common;
using JetBrains.Annotations;
using Zenject;

namespace _Project.Scripts.MiniGame.Games.Test
{
	[UsedImplicitly]
	public class TestMiniGameMediator : IMiniGameMediator
	{
		[Inject]
		private MainButtonController _mainButtonController = null!;
		[Inject]
		private TestMiniGameLogic _gameLogic = null!;

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
