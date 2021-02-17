using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTime.Core.Models;

namespace WorkTime.Database.Configurations
{
	public class TimeFrameConfiguration : BaseModelConfiguration<TimeFrame> {
		public override void Configure(EntityTypeBuilder<TimeFrame> builder)
		{
			base.Configure(builder);
			builder.Ignore(tf => tf.Span);
		}
	}
}
