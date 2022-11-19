using System;

namespace _Project.Scripts.MiniGame.Common
{
	public interface IMiniGame
	{
		event Action<bool>? OnFinished;

		MiniGameType GameType { get; }
	}
}
