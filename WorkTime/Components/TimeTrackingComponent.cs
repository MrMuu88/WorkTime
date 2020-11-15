using System;
using System.Timers;
using WorkTime.Interfaces;
using WorkTime.Models;

namespace WorkTime.Components
{
	public class TimeTrackingComponent
	{
		public WorkDay CurrentWorkDay { get; set; }
		public IMessenger Messenger { get; }
		public bool IsEnabled { get => timer.Enabled; set => timer.Enabled = value; }

		private readonly Timer timer = new Timer { AutoReset = true, Interval = 60000, Enabled = true };

		public TimeTrackingComponent(IMessenger messenger)
		{
			Messenger = messenger;
			timer.Elapsed += (s, e) => OnTimerElapsed(CurrentWorkDay); //a traditional Eventhandler cannot be unit tested
		}

		internal void OnTimerElapsed(WorkDay workday){
			var NotWorkedMinutes = (int)Math.Floor((DateTime.Now - workday.LastWorked).TotalMinutes);
			workday.Minutes.AddRange(new bool[NotWorkedMinutes]);
			workday.Minutes.Add(true);
		}

		public void Start() {
			CurrentWorkDay = new WorkDay();
			timer.Start();
		}


		public void Stop() {
			timer.Stop();
		}
	}
}
