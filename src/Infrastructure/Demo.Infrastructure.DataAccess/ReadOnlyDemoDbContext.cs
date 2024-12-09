using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.DataAccess
{
    public class ReadOnlyDemoDbContext : BaseDemoDbContext
    {
        public ReadOnlyDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}