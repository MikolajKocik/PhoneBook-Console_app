using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book;

public class DeleteContact : IContactManagement
{
    private readonly List<Contact> _contacts;
    public DeleteContact(List<Contact> contacts)
    {
        _contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));
    }
    public void Execute()
    {
        Console.WriteLine("Podaj nazwę kontaktu do usunięcia");
        string userInputId = Console.ReadLine();


        if (Guid.TryParse(userInputId, out Guid id))
        {
            var removeContact = _contacts.FirstOrDefault(c => c.Id == id);

            if (removeContact != null)
            {
                _contacts.Remove(removeContact);
                Console.WriteLine($"Kontakt o identyfikatorze {id} został pomyślnie usunięty");
            }
            else
            {
                Console.WriteLine($"Nie znaleziono kontaktu z identyfikatorem {id}.");
            }
        }
        else
        {
            Console.WriteLine("Podano nieprawidłowy identyfikator.");
        }
    }
}
