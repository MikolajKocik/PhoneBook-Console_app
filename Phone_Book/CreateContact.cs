using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Phone_Book;

public class CreateContact : IContactManagement
{

    private readonly List<Contact> _contacts;
    public CreateContact(List<Contact> contacts)
    {
        _contacts = contacts ?? new List<Contact>();
    }

    public void Execute()
    {
        Console.WriteLine("\nPodaj imię");           
        string firstName = validateDignity();

        Console.WriteLine("\nPodaj nazwisko");
        string lastName = validateDignity();

        string validateDignity() // godność (imie, nazwisko)
        {
            Dignity:
            string value = Console.ReadLine();
            string pattern = @"^[A-ZĄĆŁŃÓŚŻŹ][a-ząćęłńóśżź]*$";

            while (string.IsNullOrEmpty(value) || !Regex.IsMatch(value, pattern))
            {
                Console.WriteLine("Niepoprawna lub pusta wartość, spróbuj ponownie");
                goto Dignity;
            }
            return value;
        }

        Console.WriteLine(); // odstęp

        Console.WriteLine("Dodaj numer telefonu (format: 123 456 789 / +48 123 456 789");
        PhoneNumber:
        string phoneNumber = Console.ReadLine();
        string pattern = @"(\+48\s)?\d{3}\s\d{3}\s\d{3}$";

        while(string.IsNullOrEmpty(phoneNumber) || !Regex.IsMatch(phoneNumber, pattern))
        {
            Console.WriteLine("Niepoprawny format lub możliwa wartość null, spróbuj ponownie");
            goto PhoneNumber;
        }

        Contact newContact = new Contact(firstName, lastName, phoneNumber) // required 
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
        };

        _contacts.Add(newContact);

        Console.WriteLine($"Utworzono nowy kontakt: {newContact}"); // wywołanie metody ToString();
        Console.WriteLine("Zachowaj identyfikator w celu przyszłych modyfikacji");

    }
}
