using System;
using System.Collections.Generic;

namespace Phone_Book;

public class EditContact
{
    private readonly List<Contact> _contacts;

    public EditContact(List<Contact> contacts)
    {
        _contacts = contacts ?? throw new ArgumentNullException(nameof(contacts));
    }

    public void Execute()
    {
        if (!_contacts.Any())
        {
            Console.WriteLine("Brak kontaktów do edycji.");
            return;
        }

        Console.WriteLine("Wybierz kontakt do edycji:");
        for (int i = 0; i < _contacts.Count; i++)
        {
            Console.WriteLine($"({i + 1}) {_contacts[i]}"); // Wywołanie ToString()
            // i + 1 w pętli pozwala na wyświetlanie numeracji od 1, co jest wygodniejsze dla użytkownika
            // Rzeczywisty indeks w liście (i) pozostaje ten sam (zaczyna się od 0)
        }

        int contactIndex;
        while (!int.TryParse(Console.ReadLine(), out contactIndex) || contactIndex < 1 || contactIndex > _contacts.Count)
        {
            Console.WriteLine("Niepoprawny wybór. Wprowadź prawidłowy numer kontaktu.");
        }

        var contact = _contacts[contactIndex - 1];
        // aby uzyskać poprawny element z listy, musimy odjąć 1 od wprowadzonego przez użytkownika numeru
        // bo lista _contacts operuje na indeksach zaczynających się od 0

        Console.WriteLine($"Edytujesz kontakt: {contact}");

        int option;
        do
        {
            Console.WriteLine("Wybierz wartość do zmiany:");
            Console.WriteLine("(1) Imię");
            Console.WriteLine("(2) Nazwisko");
            Console.WriteLine("(3) Numer telefonu");
            Console.WriteLine("(0) Wyjście");

            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Niepoprawna opcja. Wprowadź liczbę.");
            }

            switch (option)
            {
                case 1:
                    Console.WriteLine("Podaj nowe imię:");
                    string newFirstName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newFirstName))
                    {
                        Console.WriteLine("Imię nie może być puste.");
                    }
                    else
                    {
                        contact.FirstName = newFirstName;
                        Console.WriteLine("Imię zostało zmienione.");
                    }
                    break;

                case 2:
                    Console.WriteLine("Podaj nowe nazwisko:");
                    string newLastName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newLastName))
                    {
                        Console.WriteLine("Nazwisko nie może być puste.");
                    }
                    else
                    {
                        contact.LastName = newLastName;
                        Console.WriteLine("Nazwisko zostało zmienione.");
                    }
                    break;

                case 3:
                    Console.WriteLine("Podaj nowy numer telefonu:");
                    string newPhoneNumber = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newPhoneNumber))
                    {
                        Console.WriteLine("Numer telefonu nie może być pusty.");
                    }
                    else
                    {
                        contact.PhoneNumber = newPhoneNumber;
                        Console.WriteLine("Numer telefonu został zmieniony.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Zakończono edycję.");
                    break;

                default:
                    Console.WriteLine("Niepoprawna opcja.");
                    break;
            }
        }
        while (option != 0);
    }
}
