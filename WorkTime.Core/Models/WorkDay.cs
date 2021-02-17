using System;
using System.Collections.Generic;

namespace WorkTime.Core.Models
{
	public class WorkDay:BaseModel
	{
		public DateTime Date { get; private set; }
		public List<TimeFrame> TimeFrames { get; internal set; } = new List<TimeFrame>() { new TimeFrame() };

		public WorkDay()
		{
			Date = DateTime.Now.Date;
		}
	}
}
