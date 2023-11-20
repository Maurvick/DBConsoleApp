using EntityFramework.Models;

namespace EntityFramework.Database
{
    class ContactManager
    {
        public static void AddContact(Contact contact)
        {
            using (Application db = new Application())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }

            Console.WriteLine($"- Contact {contact.Name} successfully added.");
        }

        public static void UpdateContact(Contact contact)
        {
            using (Application db = new Application())
            {
                var existingContact = db.Contacts.FirstOrDefault(c => c.Id == contact.Id);

                if (existingContact != null)
                {
                    existingContact.Name = contact.Name;
                    existingContact.PhoneNumber = contact.PhoneNumber;
                    existingContact.Address = contact.Address;

                    db.SaveChanges();
                }

                Console.WriteLine($"- Contact {contact.Name} successfully updated.");
            }
        }

        public static void DeleteContact(int contactId)
        {
            using (Application db = new Application())
            {
                var contactToDelete = db.Contacts.FirstOrDefault(c => c.Id == contactId);

                if (contactToDelete != null)
                {
                    db.Contacts.Remove(contactToDelete);
                    db.SaveChanges();
                    Console.WriteLine($"- Contact with id: {contactId} deleted.");
                }
                else
                {
                    Console.WriteLine($"- Contact with id: {contactId} does not exist.");
                }
               
            }
        }

        public static void ShowContacts()
        {
            using (Application db = new Application())
            {
                var _contacts = db.Contacts.ToList();

                Console.WriteLine("List of objects: ");

                foreach (Contact contact in _contacts)
                {
                    Console.WriteLine($"- Id: {contact.Id}, Name: {contact.Name}, PhoneNumber: {contact.PhoneNumber}, Email: {contact.Address}");
                }
            }
        }
    }
}
