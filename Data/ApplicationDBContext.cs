using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Users { get; set; }
    }
}
