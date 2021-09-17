using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Flatties.Matching.Domain.Tests
{
    public class FlatTests
    {
        [Test]
        public void CanAddFlatmateToFlat()
        {
            // Arrange
            var flat = new Flat();

            // Act
            flat.AddFlatmate(new Flatmate(Guid.NewGuid()));

            // Assert
            flat.Flatmates.Count().Should().Be(1);
        }

        [Test]
        public void CanRemoveFlatmateFromFlat()
        {
            // Arrange
            var flat = new Flat();
            var flatmate = new Flatmate(Guid.NewGuid());
            flat.AddFlatmate(flatmate);

            // Act
            flat.RemoveFlatmate(flatmate);

            // Assert
            flat.Flatmates.Count().Should().Be(0);
        }

        [Test]
        public void CannotRemoveNonExistentFlatmateFromFlat()
        {
            // Arrange, Act & Assert
            FluentActions.Invoking(() => new Flat().RemoveFlatmate(new Flatmate(Guid.NewGuid())))
                .Should().Throw<ArgumentException>();
        }

        [Test]
        public void CannotAddTheSameFlatmateTwice()
        {
            // Arrange
            var flatmate = new Flatmate(Guid.NewGuid());
            var flat = new Flat(new Flatmate[] { flatmate });

            // Act & Assert
            FluentActions.Invoking(() => flat.AddFlatmate(flatmate))
                .Should().Throw<ArgumentException>();
        }
    }
}
