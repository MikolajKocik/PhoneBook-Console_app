using System;
using System.Collections.Generic;

namespace Phone_Book;

public class Program
{
    public delegate void Display(string value);
    private static List<Contact> _contacts = new List<Contact>();
    static void Main()
    {
        Display display = value => Console.WriteLine(value);
        Console.Title = "Phone_Book";

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            display("===TWOJA KSIĄŻKA TELEFONICZNA===");
            Console.ForegroundColor = ConsoleColor.White;
            display("\nWybierz opcję: ");

            display("\n(1) Dodaj nowy kontakt");
            display("(2) Edytuj kontakt");
            display("(3) Wyświetl wszystkie kontakty");
            display("(4) Wyświetl dany kontakt");
            display("(5) Dodaj kontakt do ulubionych");
            display("(6) Wyjdź");
            
            Console.WriteLine();

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("\nNiepoprawna opcja. Wprowadź liczbę.");
                Console.WriteLine("-------------------------------------");
                option = int.Parse(Console.ReadLine());
            }
            switch (option)
            {
                case 1:
                    CreateContact create = new CreateContact(_contacts);
                    create.Execute();
                    break;
                case 2:
                    EditContact edit = new EditContact(_contacts);
                    edit.Execute();
                    break;
                case 3:             
                    SearchAllContacts searchAllContacts = new SearchAllContacts(_contacts);
                    searchAllContacts.Execute();
                    break;
                case 4:
                    SearchContactByPhoneNumber search = new SearchContactByPhoneNumber(_contacts);
                    search.Execute();
                    break;
                case 5:
                    Console.WriteLine("Podaj numer telefonu kontaktu, który chcesz oznaczyć jako ulubiony:");
                    string phoneNumber = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        Console.WriteLine("Numer telefonu nie może być pusty.");
                    }
                    else
                    {
                        try
                        {
                            _contacts.SetAsFavourite(phoneNumber); // Wywołanie metody rozszerzającej
                            Console.WriteLine("Operacja zakończona.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
                        }
                    }
                    break;
                default:
                    break;


            }
        }
    }
}
