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

		public WorkTimeDbContext(){}

		public WorkTimeDbContext(DbContextOptions<WorkTimeDbContext> options):base(options){}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlite(@"Data Source=.\workTime.db;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//All IEntityTypeconfiguration<T> calss will be loaded from assemby
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BaseModelConfiguration<BaseModel>)));
		}
	}
}
