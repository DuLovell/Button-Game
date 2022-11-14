using _Project.Scripts.Managers.Logger;
using JetBrains.Annotations;

namespace _Project.Scripts.MiniGame
{
	[UsedImplicitly]
	public class MiniGameFactory
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<MiniGameFactory>();
		
		public IMiniGame CreateMiniGame(MiniGameType gameType)
		{
			_logger.Debug($"MiniGame was created! type={gameType}");
			return null;
		}
	}
}
