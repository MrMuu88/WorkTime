using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using WorkTime.Interfaces;
using WorkTime.Models;

namespace WorkTime.Components
{
	public class TimeTrackingComponent : ITimeTracker
	{
		public WorkDay CurrentWorkDay { get; set; }
		public IMessenger Messenger { get; }
		public ISettingManager SettingManager { get; }
		public TimeSpan TrackingInterval {get;}
		private readonly Timer timer; 

		//TODO On sdettings Changed event restart the timer with new values
		public TimeTrackingComponent(IMessenger messenger, ISettingManager settingManager)
		{
			Messenger = messenger;
			SettingManager = settingManager;
			TrackingInterval = TimeSpan.FromMinutes(SettingManager.Settings.TimeTracking.TrackingInterval);

			CurrentWorkDay = new WorkDay(); //TODO Move this outside of this ctor

			timer = new Timer { 
				AutoReset = true,
				Interval =TrackingInterval.TotalMilliseconds,
				Enabled = false
			};
			timer.Elapsed += (s, e) => OnTimerElapsed();				//a traditional Eventhandler cannot be unit tested
		}

		internal void OnTimerElapsed(){
			var currentTimeframe = CurrentWorkDay.TimeFrames.Last();

			var now = DateTime.Now;
			var elapsed =(now-currentTimeframe.LastCheck);
			var checkAgainst = TrackingInterval.Add(TimeSpan.FromSeconds(1)); // adding 1 sec to compensate for milisieconds inconsistencies

			Trace.WriteLine($"{elapsed.TotalSeconds}s <= {checkAgainst.TotalSeconds} s");
			if (elapsed <= checkAgainst) 
			{
				currentTimeframe.LastCheck = now;
			}
			else
			{
				currentTimeframe = new TimeFrame();
				CurrentWorkDay.TimeFrames.Add(currentTimeframe);
			}
				
			
			
		}

		public void Start() {
			timer.Start();
			OnTimerElapsed();
		}

		public void Stop() {
			timer.Stop();
		}
	}
}
