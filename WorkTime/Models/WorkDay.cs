using System;
using System.Collections.Generic;

namespace WorkTime.Models
{
	public class WorkDay
	{
		public DateTime Started { get; internal set; } = DateTime.Now;
		public DateTime LastWorked { get; internal set; } = DateTime.Now;

		public List<TimeFrame> TimeFrames { get; internal set; } = new List<TimeFrame>() { new TimeFrame(DateTime.Now,default)};
		
		public WorkDay(){}

		public WorkDay(DateTime started)
		{
			Started = started;
			LastWorked = started;
		}

		internal WorkDay(DateTime started, DateTime lastWorked)
		{
			Started = started;
			LastWorked = lastWorked;
		}
	}
}
