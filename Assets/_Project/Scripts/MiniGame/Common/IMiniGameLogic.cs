using System;

namespace _Project.Scripts.MiniGame.Common
{
	public interface IMiniGameLogic
	{
		event Action? OnGameStarted; 
		event Action<bool>? OnGameFinished;
		
		void StartGame();
		void OnMainButtonPressed();
	}
}
