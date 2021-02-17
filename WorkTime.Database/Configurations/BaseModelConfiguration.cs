using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkTime.Core.Models;

namespace WorkTime.Database.Configurations
{
	public class BaseModelConfiguration<T> : IEntityTypeConfiguration<T> where T:BaseModel 
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.HasKey(bm => bm.Id);
		}
	}
}
