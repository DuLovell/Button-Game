using UnityEngine;

namespace _Project.Scripts.MiniGame.Games.Test.World
{
	public class TestMiniGameWorld : MonoBehaviour
	{
		[field: SerializeField]
		public TestMiniGameCube Cube { get; private set; } = null!;
	}
}
