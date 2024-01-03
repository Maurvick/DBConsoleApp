using EntityFramework.Services;

namespace EntityFramework
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DbConsole console = new ();

            console.ReadUserCommands();
        }
    }
}
