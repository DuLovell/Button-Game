using _Project.Scripts.MainButton;
using Zenject;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameMediator
	{
		[Inject]
		private MainButtonController _mainButtonController = null!;
		[Inject]
		private TestMiniGameLogic _gameLogic = null!;

		public void Active()
		{
			_mainButtonController.OnButtonTouched.Event += _gameLogic.OnMainButtonPressed;
		}

		public void Deactivate()
		{
			_mainButtonController.OnButtonTouched.Event -= _gameLogic.OnMainButtonPressed;
		}
	}
}
