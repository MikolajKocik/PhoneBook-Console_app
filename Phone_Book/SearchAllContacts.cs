using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book;

public class SearchAllContacts : IContactManagement
{
    private readonly List<Contact> _contacts;
    public SearchAllContacts(List<Contact> contacts)
    {
        _contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));
    }

    public void Execute()
    {
        if (_contacts.Any())
        {
            Console.WriteLine("Wszystkie kontakty");
            foreach (var contact in _contacts)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine("Książka telefoniczna nie zawiera żadnych kontaktów");
        }
    }
}
