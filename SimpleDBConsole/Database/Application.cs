using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Database
{
    // Create connection class
    class Application : DbContext
    {
        private string _name = "contactdb";
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _password = "12345qwer";

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _user = "root";

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _host = "localhost";

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        public DbSet<Contact> Contacts { get; set; }

        public Application()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server={_host};user={_user};password={_password};database={_name};",
                new MySqlServerVersion(new Version(8, 0, 25)));
        }
    }
}
