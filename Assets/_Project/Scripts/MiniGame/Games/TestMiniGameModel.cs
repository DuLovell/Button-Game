using JetBrains.Annotations;

namespace _Project.Scripts.MiniGame.Games
{
	[UsedImplicitly]
	public class TestMiniGameModel
	{
		public int TapCount;

		public void Reset()
		{
			TapCount = 0;
		}
	}
}
