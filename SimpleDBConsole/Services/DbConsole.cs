using EntityFramework.Models;

namespace EntityFramework.Services
{
    class DbConsole
    {
        Application app = new Application();

        public void ReadUserCommands()
        {
            bool isRunning = true;

            Console.WriteLine("- Available commands: " + 
                "change db, current db, change db settings, show contacts, add contact, update contact, delete contact, exit.");

            while (isRunning)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine() ?? "";

                string[] commandArgs = userInput.Split(' ');
                string command = commandArgs[0].ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                switch (command)
                {
                    case "greet":
                        if (commandArgs.Length > 1)
                        {
                            string name = commandArgs[1];
                            Greet(name);
                        }
                        else
                        {
                            Console.WriteLine("Please provide a name to greet.");
                        }
                        break;
                    case "change db":
                        ChangeDb();
                        break;
                    case "current db":
                        ShowCurrentDb();
                        break;
                    case "change db settings":
                        ChangeDbSettings();
                        break;
                    case "show contacts":
                        ContactManager.ShowContacts();
                        break;
                    case "contact":
                        if (commandArgs.Length > 1)
                        {
                            string arg = commandArgs[1];
                            ReadUserArguments(arg);
                        }
                        else
                        {
                            Console.WriteLine("Please provide a add or update.");
                        }
                        break;
                    case "delete contact":
                        Console.Write("Contact id: ");
                        userInput = Console.ReadLine() ?? "";
                        ContactManager.DeleteContact(int.Parse(userInput));
                        break;
                    case "exit":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("- Wrong input!");
                        break;
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("  help        - Show available commands");
            Console.WriteLine("  greet <name>- Greet the specified name");
            Console.WriteLine("  exit        - Exit the CommandHandler");
        }

        private static void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        private void ShowCurrentDb()
        {
            Console.WriteLine($"DB: {app.Name}, Host: {app.Host}, " +
                $"User: {app.User}, Password: {app.Password}");
        }

        private void ChangeDbSettings()
        {
            Console.Write("DB name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("DB host: ");
            string host = Console.ReadLine() ?? "";
            Console.Write("DB user: ");
            string user = Console.ReadLine() ?? "";
            Console.Write("DB password: ");
            string password = Console.ReadLine() ?? "";

            app.Name = name;
            app.Host = host;
            app.User = user;
            app.Password = password;

            Console.WriteLine("- DB settings changed");
        }

        private void ChangeDb()
        {
            Console.Write("Enter db name: ");
            string db = Console.ReadLine() ?? "";
            app.Name = db;
            Console.WriteLine($"- Using database: {db}");
        }

        private void ReadUserArguments(string type)
        {
            Console.Write("Id: ");
            string id = Console.ReadLine() ?? "";

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("PhoneNumber: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            string address = Console.ReadLine() ?? "";

            // Додавання контакту
            Contact newContact = new Contact
            {
                Id = int.Parse(id),
                Name = name,
                PhoneNumber = description,
                Address = address
            };

            if (type == "add")
            {
                ContactManager.AddContact(newContact);
            }
            if (type == "update")
            {
                ContactManager.UpdateContact(newContact);
            }
        }
    }
}
