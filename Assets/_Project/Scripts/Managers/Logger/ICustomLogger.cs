namespace _Project.Scripts.Managers.Logger
{
	public interface ICustomLogger
	{
		void Debug(string message);
		void Warn(string message);
		void Error(string message);
	}
}
