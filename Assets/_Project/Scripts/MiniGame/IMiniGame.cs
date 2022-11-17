using System;

namespace _Project.Scripts.MiniGame
{
	public interface IMiniGame
	{
		event Action<bool>? OnFinished;

		MiniGameType GameType { get; }
	}
}
