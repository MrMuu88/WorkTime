using System;

namespace WorkTime.ViewModels.DTOs
{
	public class TimeFrameDTO : ViewModelBase
	{
		private DateTime start;
		private DateTime end;
		public DateTime Start { get => start; set { start = value; Changed(); } }
		public DateTime End { get => end; set { end = value; Changed(); } }
		public TimeSpan Span { get => End - Start; }

	}
}
