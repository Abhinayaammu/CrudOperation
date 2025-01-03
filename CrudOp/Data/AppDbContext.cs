using Microsoft.EntityFrameworkCore;
using OperationCrud.Models;

namespace OperationCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }

    }
}
