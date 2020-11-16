using System;

namespace WorkTime.Models
{
	public class TimeFrame
	{
		public DateTime Started { get; internal set; }
		public TimeSpan Span {get;internal set;}
		public TimeFrameType Type { get; internal set; }
		public TimeFrame(DateTime started, TimeSpan span, TimeFrameType type = TimeFrameType.Work)
		{
			Started = started;
			Span = span;
			Type = type;
		}
	}

	public enum TimeFrameType { Work,Break}
}
