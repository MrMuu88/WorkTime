namespace WorkTime.Core.Models.Settings
{
	public class MenuSettings
	{
		public WorkItemType StartMenuAt { get; set; } = WorkItemType.Requirement;
		public bool MyAssignmentsOnly { get; set; } = true;
	}
}
