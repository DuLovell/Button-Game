using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	[UsedImplicitly]
	public class TestMiniGameWorld
	{
		private TestMiniGameCube? _cube;

		public TestMiniGameCube Cube
		{
			get
			{
				if (_cube == null) {
					_cube = Object.FindObjectOfType<TestMiniGameCube>();
				}
				return _cube;
			}
		}
	}
}
