using UnityEngine;

namespace _Project.Scripts.MiniGame.Games
{
	public class TestMiniGame : MonoBehaviour, IMiniGame
	{
		private bool _isWin;
		private bool _isLose;
		private bool _isExplode;

		public void StartGame()
		{
		}

		public void StopGame()
		{
		}

		public bool CheckWin()
		{
			return _isWin;
		}

		public bool CheckLose()
		{
			return _isLose;
		}

		public bool CheckExplosion()
		{
			return _isExplode;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.W)) {
				_isWin = true;
			} else if (Input.GetKeyDown(KeyCode.L)) {
				_isLose = true;
			} else if (Input.GetKeyDown(KeyCode.E)) {
				_isExplode = true;
			}
		}
	}
}
