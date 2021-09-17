using System;

namespace Flatties.Matching.Domain
{
    public class Application
    {
        public Guid Id { get; set; }
        public Guid FlatId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
