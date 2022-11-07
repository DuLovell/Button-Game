using System;

namespace _Project.Scripts.Utilities
{
	public class EventObject
	{
		public event Action? Event;

		public void Invoke()
		{
			Event?.Invoke();
		}
	}
}
