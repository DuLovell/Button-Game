using System;
using static UnityEngine.Debug;

namespace _Project.Scripts.Services.Logger
{
	public class CustomLogger : ICustomLogger
	{
		private readonly Type _sender;

		public CustomLogger(Type sender)
		{
			_sender = sender;
		}
		
		public void Debug(string message)
		{
			Log($"[{_sender.Name}] {message}");
		}

		public void Warn(string message)
		{
			LogWarning($"[{_sender.Name}] {message}");
		}

		public void Error(string message)
		{
			LogError($"[{_sender.Name}] {message}");
		}
	}
}
