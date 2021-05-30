namespace WorkTime.Core.Models.Settings
{
	public class AppSettings
	{
		public DevOpsSettings DevOps { get; set; } = new DevOpsSettings();

		public MenuSettings Menu { get; set; } = new MenuSettings();
		public bool StartWithWindows { get; set; } = true;
	}

	public class MenuSettings
	{
		public WorkItemType StartMenuAt { get; set; } = WorkItemType.Requirement;
		public bool MyAssignmentsOnly { get; set; } = true;
	}
}
