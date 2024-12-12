using System;

namespace Phone_Book;

public class Program
{
    private static List<Contact> _contacts = new List<Contact>();
    static void Main()
    {

        CreateContact createContact = new CreateContact();

        while (true)
        {
            Console.WriteLine("\n1. Dodaj nowy kontakt");
            Console.WriteLine("2. Wyświetl wszystkie kontakty");
            Console.WriteLine("3. Wyjdź");
            Console.Write("Wybierz opcję: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Tworzenie nowego kontaktu
                    Execute();
                    break;
                case "2":
                    // Wyświetlanie wszystkich kontaktów
                    Console.WriteLine("\nLista kontaktów:");
                    foreach (var contact in _contacts)
                    {
                        Console.WriteLine(contact);
                    }
                    break;
                case "3":
                    // Wyjście z aplikacji
                    Console.WriteLine("Zamykanie programu...");
                    return;
                default:
                    Console.WriteLine("Niepoprawna opcja, spróbuj ponownie.");
                    break;


            }
        }
    }
}
