using _Project.Scripts.MiniGame.Games.Common;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameController : MiniGameController
	{
		public override MiniGameType GameType
		{
			get { return MiniGameType.FILL_WITHOUT_EXPLODE; }
		}
	}
}
