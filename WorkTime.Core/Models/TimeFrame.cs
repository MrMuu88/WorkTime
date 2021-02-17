using System;

namespace WorkTime.Core.Models
{
	public class TimeFrame
	{
		private DateTime lastCheck;

		public DateTime Start { get; private set; }
		public DateTime LastCheck { get => lastCheck; set { lastCheck = value; End = value; } }
		public DateTime End { get; set; }

		public TimeSpan Span { get => End - Start; }

		public TimeFrame()
		{
			Start = DateTime.Now;
			LastCheck = Start;
			End = Start;

		}


	}

}
