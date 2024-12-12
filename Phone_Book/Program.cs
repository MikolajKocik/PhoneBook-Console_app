using System;

namespace Phone_Book;

public class Program
{
    public delegate void Display(string value);
    private static List<Contact> _contacts = new List<Contact>();
    static void Main()
    {
        Display display = value => Console.WriteLine(value);

        while (true)
        {
            display("===TWOJA KSIĄŻKA TELEFONICZNA===");
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
                Console.WriteLine("Niepoprawna opcja. Wprowadź liczbę.");
                continue; // Przejdź do następnej iteracji
            }
            switch (option)
            {
                case 1:
                    CreateContact create = new CreateContact(_contacts);
                    create.Execute();
                    break;
                case 2:
                    break;
                case 3:                  
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;


            }
        }
    }
}
