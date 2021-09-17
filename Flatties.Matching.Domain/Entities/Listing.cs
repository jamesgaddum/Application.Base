using System;

namespace Flatties.Matching.Domain
{
    public class Listing
    {
        public Guid RoomId { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? AvailableUntil { get; set; }
        public Rent Rent { get; set; }
        public ListingStatus Status { get; set; }
    }
}
