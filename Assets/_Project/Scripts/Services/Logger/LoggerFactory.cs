using System;

namespace _Project.Scripts.Services.Logger
{
	public static class LoggerFactory
	{
		private const LoggerType LOGGER_TYPE = LoggerType.CUSTOM;
		
		public static ICustomLogger GetLogger<T>()
		{
			switch (LOGGER_TYPE) {
				case LoggerType.CUSTOM:
					return new CustomLogger(typeof(T));
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		private enum LoggerType
		{
			CUSTOM
		}
	}
}
