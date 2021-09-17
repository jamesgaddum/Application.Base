using System;
using System.Collections.Generic;

namespace Flatties.Matching.Domain
{
    public class Flat
    {
        public Flat()
        {
        }

        public Flat(ICollection<Flatmate> flatmates)
        {
            if (flatmates == null)
            {
                throw new ArgumentNullException("Flatmates cannot be null");
            }

            _flatMates = flatmates;
        }

        public Guid Id { get; set; }
        public Residence Residence { get; set; }
        private ICollection<Flatmate> _flatMates = new HashSet<Flatmate>();
        public ICollection<Flatmate> Flatmates
        {
            get { return _flatMates; }
            private set { _flatMates = value; }
        }

        public void AddFlatmate(Flatmate flatmate)
        {
            if (_flatMates.Contains(flatmate))
            {
                throw new ArgumentException("Flatmate already exists in the flat");
            }

            _flatMates.Add(flatmate);
        }

        public void RemoveFlatmate(Flatmate flatmate)
        {
            if (!_flatMates.Contains(flatmate))
            {
                throw new ArgumentException("Flatmate does not exist in the flat");
            }

            _flatMates.Remove(flatmate);
        }
    }
}
