using System;

namespace Application.Base.Domain
{
    public class User
    {
        public UserId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public record UserId(string Value);
}
