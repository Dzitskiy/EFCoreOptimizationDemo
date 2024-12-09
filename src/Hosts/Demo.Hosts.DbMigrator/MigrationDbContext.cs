using Demo.Infrastructure.DataAccess;

namespace Demo.Hosts.DbMigrator
{
    /// <summary>
    /// Контест БД для мигратора.
    /// </summary>
    public class MigrationDbContext : Infrastructure.DataAccess.BaseDemoDbContext
    {
        public MigrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options)
        {
        }
    }
}
