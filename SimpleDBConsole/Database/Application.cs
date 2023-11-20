using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Database
{
    // Create connection class
    class Application : DbContext
    {
        public static string dbName = "contactdb";
        public static string dbPassword = "12345qwer";
        public static string dbUser = "root";
        public static string dbServer = "localhost";

        public DbSet<Contact> Contacts { get; set; } = null!;

        public Application()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server={dbServer};user={dbName};password={dbPassword};database={dbName};",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }
}
