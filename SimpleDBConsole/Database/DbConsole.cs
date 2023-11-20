using EntityFramework.Models;

namespace EntityFramework.Database
{
    class DbConsole
    {
        public void ReadUserCommands()
        {
            string userInput;
            bool isRunning = true;

            Console.WriteLine("- Available commands: " + 
                "change db, current db, change db settings, show contacts, add contact, update contact, delete contact, exit.");

            while (isRunning)
            {
                Console.Write("> ");
                userInput = Console.ReadLine();
                
                switch (userInput.ToLower())
                {
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
                    case "add contact":
                        ReadUserArguments("add");
                        break;
                    case "update contact":
                        ReadUserArguments("update");
                        break;
                    case "delete contact":
                        Console.Write("Contact id: ");
                        userInput = Console.ReadLine();
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

        private void ShowCurrentDb()
        {
            Console.WriteLine($"DB: {Application.dbName}, Host: {Application.dbServer}, " +
                $"User: {Application.dbUser}, Password: {Application.dbPassword}");
        }

        private void ChangeDbSettings()
        {
            Console.Write("DB name: ");
            string name = Console.ReadLine();
            Console.Write("DB host: ");
            string host = Console.ReadLine();
            Console.Write("DB user: ");
            string user = Console.ReadLine();
            Console.Write("DB password: ");
            string password = Console.ReadLine();

            Application.dbName = name;
            Application.dbServer = host;
            Application.dbUser = user;
            Application.dbPassword = password;

            Console.WriteLine("- DB settings changed");
        }

        private void ChangeDb()
        {
            Console.Write("Enter db name: ");
            string db = Console.ReadLine();
            Application.dbName = db;
            Console.WriteLine($"- Using database: {db}");
        }

        private void ReadUserArguments(string type)
        { 
            Console.Write("Id: ");
            string id = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("PhoneNumber: ");
            string description = Console.ReadLine();

            Console.Write("Email: ");
            string address = Console.ReadLine();

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
