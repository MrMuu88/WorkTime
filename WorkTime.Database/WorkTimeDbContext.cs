using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorkTime.Core.Models;
using WorkTime.Database.Configurations;

namespace WorkTime.Database
{
	public class WorkTimeDbContext : DbContext
	{
		public DbSet<WorkDay> Days {get;set;}
		public DbSet<TimeFrame> TimeFrames { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//All IEntityTypeconfiguration<T> calss will be loaded from assemby
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BaseModelConfiguration<BaseModel>)));
		}
	}
}
