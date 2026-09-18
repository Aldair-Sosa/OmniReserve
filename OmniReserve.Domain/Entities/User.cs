using OmniReserve.Domain.Enums;

namespace OmniReserve.Domain.Entities;

public class User
{
    public Guid Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public string PasswordHash {get; set;}
    public Role Role {get; set;}

    public User(string firstName, string lastName, string email, string passwordHash, Role role)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentNullException(nameof(passwordHash));

        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
}

