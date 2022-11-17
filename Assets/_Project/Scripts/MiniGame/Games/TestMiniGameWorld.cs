using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGameWorld : MonoBehaviour
	{
		[field: SerializeField]
		public TestMiniGameCube Cube { get; private set; } = null!;
	}
}
