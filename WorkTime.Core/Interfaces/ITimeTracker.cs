using WorkTime.Core.Models;

namespace WorkTime.Core.Interfaces
{
	public interface ITimeTracker
	{
		WorkDay CurrentWorkDay { get; set; }

		void Start();
		void Stop();
	}
}