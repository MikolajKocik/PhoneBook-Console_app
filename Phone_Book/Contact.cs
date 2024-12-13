using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book;

public class Contact 
{
    public Guid Id { get; private set; }
    public required string FirstName { get; set; }
    public string LastName { get; set; }   
    public required string PhoneNumber { get; set; }
    public bool IsFavourite { get; set; }

    public Contact(string firstName, string phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        PhoneNumber = phoneNumber;
    }

    public Contact(string firstName, string lastName, string phoneNumber): this(firstName, phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
    public Contact(string firstName, string lastName, string phoneNumber, bool isFavourite) : this(firstName, lastName, phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        IsFavourite = isFavourite;
    }

    public override string ToString()
    {
        return IsFavourite ? 
            $"[Ulubiony] {FirstName} {LastName} - {PhoneNumber}, unikalny identyfikator: {Id}":
            $"{FirstName} {LastName} - {PhoneNumber}, unikalny identyfikator: {Id}";
    }
}
