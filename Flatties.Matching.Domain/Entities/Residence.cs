using System;
using System.Collections.Generic;

namespace Flatties.Matching.Domain
{
    public class Residence
    {
        public Guid Id { get; set; }
        public StreetAddress StreetAddress { get; set; }
        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
    }
}
