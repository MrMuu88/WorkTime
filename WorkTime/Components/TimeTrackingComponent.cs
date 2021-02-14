using System;
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
		public double TrackingInterval {get;}
		private readonly Timer timer; 

		//TODO On sdettings Changed event restart the timer with new values
		public TimeTrackingComponent(IMessenger messenger, ISettingManager settingManager)
		{
			Messenger = messenger;
			SettingManager = settingManager;
			TrackingInterval = settingManager.Settings.TimeTracking.TrackingInterval;

			timer = new Timer { AutoReset = true, Interval = TrackingInterval, Enabled = true };
			timer.Elapsed += (s, e) => OnTimerElapsed();				//a traditional Eventhandler cannot be unit tested
		}

		internal void OnTimerElapsed(){
			var currentTimeframe = CurrentWorkDay.TimeFrames.FirstOrDefault();

			if (currentTimeframe == null) {
				currentTimeframe = new TimeFrame();
				CurrentWorkDay.TimeFrames.Add(currentTimeframe);
			}
			
			var elapsed =(int) Math.Floor((DateTime.Now - currentTimeframe.End).TotalSeconds);
			if (elapsed < TrackingInterval)
			{
				currentTimeframe.Span.Add(TimeSpan.FromSeconds(TrackingInterval));
			}
			else
			{
				currentTimeframe = new TimeFrame();
				CurrentWorkDay.TimeFrames.Add(currentTimeframe);
			}
				
			
			
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
