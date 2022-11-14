using _Project.Scripts.Managers.Logger;
using _Project.Scripts.MiniGame;

namespace _Project.Scripts.Npc
{
	public class NpcFactory
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<NpcFactory>();
		
		public IMiniGame CreateMiniGame(MiniGameType gameType)
		{
			_logger.Debug($"MiniGame was created! type={gameType}");
			return null;
		}
	}
}
