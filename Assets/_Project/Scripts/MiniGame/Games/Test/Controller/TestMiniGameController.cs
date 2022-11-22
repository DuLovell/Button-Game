using _Project.Scripts.MiniGame.Common;

namespace _Project.Scripts.MiniGame.Games.Test.Controller
{
	public class TestMiniGameController : MiniGameController
	{
		public override MiniGameType GameType
		{
			get { return MiniGameType.FILL_WITHOUT_EXPLODE; }
		}
	}
}
