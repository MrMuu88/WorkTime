using System;
using System.Collections.Generic;

namespace WorkTime.Models
{
	public class WorkDay
	{
		public DateTime Date {get; private set;}
		public List<TimeFrame> TimeFrames { get; internal set; } = new List<TimeFrame>() {};
		
		public WorkDay(){
			Date = DateTime.Now.Date;
		}
	}
}
