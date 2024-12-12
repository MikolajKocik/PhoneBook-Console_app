using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Phone_Book
{
    public class CreateContact : IContactServices
    {
        private readonly Contact _contact;
        private readonly List<Contact> _contacts;
        public CreateContact(Contact newContact)
        {
            _contact = newContact;
        }
        public void Execute(Contact _)
        {
            string valuePersonal;

            Console.WriteLine("Podaj imię");

            string firstName = Console.ReadLine();
            validateDignity(firstName);

            Console.WriteLine("Podaj nazwisko");

            string lastName = Console.ReadLine();
            validateDignity(lastName);

            void validateDignity(string valuePersonal) // godność (imie, nazwisko)
            {
                string valuePersonalValidation = @"^[A-ZĄĆŁŃÓŚŻŹ][a-ząćęłńóśżź' -]*$";

                while (string.IsNullOrEmpty(valuePersonal) || !Regex.IsMatch(valuePersonalValidation, valuePersonal))
                {
                    Console.WriteLine("Niepoprawna lub pusta wartość, spróbuj ponownie");
                    valuePersonal = Console.ReadLine();
                }
            }

            Console.WriteLine("Dodaj numer telefonu (format: 123 456 789 / +48 123 456 789");
            string phoneNumber = Console.ReadLine();
            string numerValidation = @"(\+48\s)?\d{3}\s\d{3}\s\d{3}$";

            while (string.IsNullOrEmpty(phoneNumber) || !Regex.IsMatch(numerValidation, phoneNumber))
            {
                Console.WriteLine("Niepoprawny format lub możliwa wartość null, spróbuj ponownie");
                phoneNumber = Console.ReadLine();
            }

            Contact newContact = new Contact(firstName, lastName, phoneNumber)
            {
               FirstName = firstName,
               LastName = lastName,
               PhoneNumber = phoneNumber,
            };

            _contacts.Add(newContact);

            Console.WriteLine($"Utworzono nowy kontakt: {newContact}"); // wywołanie metody ToString();

        }
    }
}
