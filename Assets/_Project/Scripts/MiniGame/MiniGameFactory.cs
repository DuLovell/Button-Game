using _Project.Scripts.MiniGame.Data;
using _Project.Scripts.Services;
using _Project.Scripts.Services.Logger;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.MiniGame
{
	[UsedImplicitly]
	public class MiniGameFactory
	{
		private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<MiniGameFactory>();

		[Inject]
		private AssetProvider _assetProvider = null!;
		[Inject]
		private MiniGamesLauncherDescriptor _miniGamesLauncherDescriptor = null!;

		public IMiniGame CreateMiniGame(MiniGameType gameType)
		{
			GameObject miniGamePrefab = _miniGamesLauncherDescriptor.GetMiniGamePrefab(gameType);
			_logger.Debug($"MiniGame was created. type={gameType}");
			return _assetProvider.CreateAsset<IMiniGame>(miniGamePrefab);
		}
	}
}
