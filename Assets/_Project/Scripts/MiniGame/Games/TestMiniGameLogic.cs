using Zenject;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameLogic
	{
		[Inject]
		private TestMiniGameWorld _gameWorld = null!;

		public void StartGame()
		{
			//TODO Куб начинает вращаться по часовой стрелке
			Cube.StartRotating();
		}

		public void OnMainButtonPressed()
		{
			//TODO Меняем направление вращение куба на противоположное
			Cube.InverseRotationDirection();
		}

		private TestMiniGameCube Cube
		{
			get { return _gameWorld.Cube; }
		}
	}
}
