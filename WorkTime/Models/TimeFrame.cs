using System;

namespace WorkTime.Models
{
	public class TimeFrame
	{
		public DateTime Start { get; internal set; }
		public DateTime End { get => Start.Add(Span); }

		public TimeSpan Span { get; set; }
		public TimeFrame()
		{
			Start = DateTime.Now;
			Span = TimeSpan.FromSeconds(0);
		}

		
	}

}
