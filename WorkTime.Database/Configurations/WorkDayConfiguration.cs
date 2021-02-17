using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTime.Core.Models;

namespace WorkTime.Database.Configurations
{
	public class WorkDayConfiguration : BaseModelConfiguration<WorkDay> {
		public override void Configure(EntityTypeBuilder<WorkDay> builder)
		{
			base.Configure(builder);
		}
	}
}
