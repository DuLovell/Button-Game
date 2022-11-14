using System;

namespace _Project.Scripts.MiniGame
{
	public interface IMiniGame
	{
		event Action? OnFinished;
		event Action? OnShowEnded;
		
		void StartGame();
		void StopGame();
		
		bool CheckWin();
		bool CheckLose();
	}
}
