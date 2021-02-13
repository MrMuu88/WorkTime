using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Timers;
using WorkTime.Interfaces;
using WorkTime.Models;

namespace WorkTime.Components
{
	public class TimeTrackingComponent:ITimeTracker
	{
		public WorkDay CurrentWorkDay { get; set; }
		public IMessenger Messenger { get; }
		private readonly Timer timer; 

		public TimeTrackingComponent(IMessenger messenger)
		{
			//TODO move settings to a settings handler class, that can send a message for SettingsChanged
			Messenger = messenger;
			timer = new Timer { AutoReset = true, Interval = Properties.Settings.Default.TrackingInterval, Enabled = true };
			timer.Elapsed += (s, e) => OnTimerElapsed(CurrentWorkDay);				//a traditional Eventhandler cannot be unit tested
		}

		internal void OnTimerElapsed(WorkDay workday){
			var dtnow = DateTime.Now;												//to eliminate ms changes between statements
			var span = dtnow - workday.LastWorked;
			var lastframe = workday.TimeFrames.Last();

			if (span.Ticks > TimeSpan.FromMilliseconds(Properties.Settings.Default.BreakTreshold).Ticks)
			{
				//Close the last frame
				
				//TODO throw an exception if the lastframe is not Work type
				lastframe.Span = (workday.LastWorked - lastframe.Started);

				//add a new beak frame
				workday.TimeFrames.Add(new TimeFrame(workday.LastWorked, span, TimeFrameType.Break));

				//add a new work Frame
				workday.TimeFrames.Add(new TimeFrame(dtnow, TimeSpan.FromMilliseconds(Properties.Settings.Default.TrackingInterval)));
			}
			else {
				lastframe.Span = lastframe.Span.Add(span);
			}

			workday.LastWorked = dtnow;
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
