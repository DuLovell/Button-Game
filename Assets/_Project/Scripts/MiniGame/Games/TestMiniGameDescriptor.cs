using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	[CreateAssetMenu(fileName = "TestMiniGameDescriptor", menuName = "Data/MiniGames/Test/Descriptor", order = 0)]
	public class TestMiniGameDescriptor : ScriptableObject
	{
		[field: SerializeField]
		public int TapsToWin { get; private set; }

		[field: SerializeField]
		public float SecondsToWin { get; private set; }
	}
}
