using LogProxyApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LogProxyApi.Data
{
    public class LogProxyDbContext : DbContext
    {
        public LogProxyDbContext(DbContextOptions<LogProxyDbContext>options):base(options)
        {
            
        }

        public DbSet<LogProxy> entities { get; set; }
    }
}
