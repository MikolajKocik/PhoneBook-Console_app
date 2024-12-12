using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book;

public static class EditContact
{
    public static void SetAsFavourite(this IEnumerable<Contact> contacts, string phoneNumber)
    {

        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }
        else if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException("Numer telefonu nie może być null albo pusty", nameof(phoneNumber));
        }

        foreach (var contact in contacts)
        {
            if (contact.PhoneNumber.Contains(phoneNumber, StringComparison.OrdinalIgnoreCase))
            {
                contact.IsFavourite = true;
            }
        }
    }
}
