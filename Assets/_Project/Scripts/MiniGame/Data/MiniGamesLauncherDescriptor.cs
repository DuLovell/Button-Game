using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Data
{
	[CreateAssetMenu(fileName = "MiniGamesLauncherDescriptor", menuName = "Data/MiniGames/LauncherDescriptor", order = 0)]
	public class MiniGamesLauncherDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public Vector2 LaunchDelayRange { get; private set; }
		
		[field: SerializeField]
		public List<GameObject> MiniGames { get; private set; } = null!;

		public GameObject GetMiniGamePrefab(MiniGameType gameType)
		{
			return MiniGames.Find(miniGame => miniGame.GetComponent<IMiniGame>().GameType == gameType);
		}
	}
}
