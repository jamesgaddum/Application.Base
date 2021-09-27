using System;

namespace Application.Base.Domain
{
    public class User
    {
        public User(string id, string firstName, DateTime dateOfBirth, string lastName = null)
        {
            Id = new UserId(id);
            FirstName = firstName ?? throw new ArgumentNullException();
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public UserId Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
    }

    public record UserId(string Value);
}
