namespace _Project.Scripts
{
	public interface IMiniGame
	{
		void StartGame();
		void StopGame();
		
		bool CheckWin();
		bool CheckLose();
		bool CheckExplosion();
	}
}
