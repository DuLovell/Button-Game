using _Project.Scripts.MiniGame.Common;
using JetBrains.Annotations;

namespace _Project.Scripts.MiniGame.Games
{
	[UsedImplicitly]
	public class TestMiniGameModel : IMiniGameModel
	{
		public int TapCount;

		public void Reset()
		{
			TapCount = 0;
		}
	}
}
