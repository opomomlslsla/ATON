using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) 
        {
           //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
