using Heikal.Lubricant.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heikal.Lubricant.Infrastructure.Data
{
    public class LubricantContext: DbContext
    {
        public LubricantContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Days> Days { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
