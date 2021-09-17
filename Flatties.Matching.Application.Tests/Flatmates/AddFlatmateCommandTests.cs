using System;
using System.Threading.Tasks;
using Flatties.Matching.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Flatties.Matching.Application.Tests
{
    using static Global;

    public class AddFlatmateCommandTests
    {
        [Test]
        public async Task ShouldCreateValidFlatmate()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid() };
            var flat = new Flat { Id = Guid.NewGuid() };

            await AddAsync(user);
            await AddAsync(flat);

            var command = new AddFlatmateCommand
            {
                FlatId = flat.Id,
                UserId = user.Id
            };

            // Act
            var response = await SendAsync(command);

            // Assert
            response.FlatId.Should().Be(command.FlatId);
            response.UserId.Should().Be(command.UserId);
        }
    }
}
