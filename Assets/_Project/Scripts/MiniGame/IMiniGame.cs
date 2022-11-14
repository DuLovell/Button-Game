namespace _Project.Scripts.MiniGame
{
	public interface IMiniGame
	{
		void StartGame();
		void StopGame();
		
		bool CheckWin();
		bool CheckLose();
	}
}
