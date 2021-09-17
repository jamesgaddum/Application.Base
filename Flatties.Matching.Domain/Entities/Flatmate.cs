using System;

namespace Flatties.Matching.Domain
{
    public class Flatmate
    {
        public Flatmate(Guid userId)
        {
            UserId = userId;
        }

        public Flat Flat { get; set; }
        public Guid FlatId { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
