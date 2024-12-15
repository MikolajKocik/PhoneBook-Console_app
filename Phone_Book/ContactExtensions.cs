using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Phone_Book;

public static class ContactExtensions
{
    public static void SetAsFavourite(this IEnumerable<Contact> contacts, string phoneNumber)
    {

        if (contacts == null)
        {
            throw new ArgumentNullException(nameof(contacts));
        }

        if (string.IsNullOrEmpty(phoneNumber))
        {
            throw new ArgumentException("Numer telefonu nie może być null albo pusty", nameof(phoneNumber));
        }

        var contact = contacts.FirstOrDefault(c => c.PhoneNumber.Contains(phoneNumber, StringComparison.OrdinalIgnoreCase));
        if (contact == null)
        {
            Console.WriteLine("Nie znaleziono kontaktu o podanym numerze telefonu.");
            return;
        }

        while (true)
        {
            Console.WriteLine("Dodaj kontakt do ulubionych [dodaj], Usuń kontakt z ulubionych [usun], Wyjdz [0]");
            string option = Console.ReadLine();

            string patternAdd = @"\b[dD]odaj\b";
            string patternDelete = @"\b[uU]suń\b";
            string close = @"^\s*0\s*$";

            
            if (string.IsNullOrEmpty(option) ||
                (!Regex.IsMatch(option, patternAdd) &&
                 !Regex.IsMatch(option, patternDelete) &&
                 !Regex.IsMatch(option, close)))
            {
                Console.WriteLine("Niepoprawna lub pusta wartość, spróbuj ponownie.");
                continue; // Powrót do początku pętli
            }

           
            if (Regex.IsMatch(option, patternAdd))
            {
                contact.IsFavourite = true;
                Console.WriteLine($"Kontakt {contact.PhoneNumber} został dodany do ulubionych.");
            }
            else if (Regex.IsMatch(option, patternDelete))
            {
                contact.IsFavourite = false;
                Console.WriteLine($"Kontakt {contact.PhoneNumber} został usunięty z ulubionych.");
            }
            else if (Regex.IsMatch(option, close))
            {
                Console.WriteLine("Zakończono operację.");
                return; 
            }
        }
    }
}
