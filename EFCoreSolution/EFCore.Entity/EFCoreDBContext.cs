using EFCore.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Entity
{
    public class EFCoreDBContext : DbContext
    {
        private string connectionString;

        public DbSet<User> Users { get; set; }

        public EFCoreDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCoreDB;Integrated Security=True"));
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
