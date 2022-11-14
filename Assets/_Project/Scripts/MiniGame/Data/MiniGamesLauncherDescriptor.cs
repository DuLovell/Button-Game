using UnityEngine;

namespace _Project.Scripts.MiniGame.Data
{
	[CreateAssetMenu(fileName = "MiniGamesLauncherDescriptor", menuName = "Data/MiniGames/LauncherDescriptor", order = 0)]
	public class MiniGamesLauncherDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public Vector2 LaunchDelayRange { get; private set; }
	}
}
