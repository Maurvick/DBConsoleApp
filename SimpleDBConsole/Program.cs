using EntityFramework.Database;

namespace EntityFramework
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DbConsole console = new DbConsole();

            console.ReadUserCommands();
        }
    }
}
