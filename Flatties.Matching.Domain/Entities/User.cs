using System;

namespace Flatties.Matching.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirebaseUid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
