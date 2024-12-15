using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book;

public class SearchContactByPhoneNumber : IContactManagement
{
    private readonly List<Contact> _contacts;
    public SearchContactByPhoneNumber(List<Contact> contacts)
    {
        _contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));

    }
    public void Execute()
    {

        Console.WriteLine("Podaj kontakt do wyszukania (imie/nazwisko/numer)");
        string userInput = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Podano nieprawidłową wartość, spróbuj ponownie");
            userInput = Console.ReadLine();
        }

        var contact = _contacts.FirstOrDefault(c =>
        c.FirstName.Contains(userInput, StringComparison.OrdinalIgnoreCase) ||
        c.LastName.Contains(userInput, StringComparison.OrdinalIgnoreCase) ||
        c.PhoneNumber.Contains(userInput));

        if (contact != null)
        {
            Console.WriteLine("Znaleziono kontakt:");

            Type contactType = contact.GetType();

            var properties = contactType.GetProperties();


            foreach (var property in properties)
            {
                var propValue = property.GetValue(contact);
                Console.WriteLine($"{property.Name}: {propValue}");  
            }
        }
        else
        {
            Console.WriteLine("Nie znaleziono kontaktu pasującego do podanych kryteriów.");
        }
    }
}
