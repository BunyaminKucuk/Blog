using Microsoft.EntityFrameworkCore;

namespace BlogAPI.DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BUNYAMIN;database=BlogApiDb;integrated security=true;");
        }

        public DbSet<Employee>Employees { get; set; }
    }
}
