using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
        }
         public DbSet<Student> student { get; set; }
    }
}
