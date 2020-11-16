using WorkTime.Models;

namespace WorkTime.Interfaces
{
	public interface ITimeTracker
	{
		WorkDay CurrentWorkDay { get; set; }

		void Start();
		void Stop();
	}
}