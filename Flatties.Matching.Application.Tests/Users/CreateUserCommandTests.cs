using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Flatties.Matching.Application.Tests
{
    using static Global;

    public class CreateUserCommandTests : TestBase
    {
        [Test]
        public async Task ShouldCreateAValidUser()
        {
            // Arrange
            var firebaseUid = Guid.NewGuid().ToString();
            var command = new CreateUserCommand
            {
                FirebaseUid = firebaseUid,
                FirstName = "Barry",
                LastName = "Madgwick",
                DateOfBirth = DateTime.Now
            };

            var query = new GetUserQuery
            {
                FirebaseUid = firebaseUid
            };

            // Act
            await SendAsync(command);
            var response = await SendAsync(query);

            // Assert
            response.FirebaseUid.Should().BeEquivalentTo(command.FirebaseUid);
            response.FirstName.Should().BeEquivalentTo(command.FirstName);
            response.LastName.Should().BeEquivalentTo(command.LastName);
            response.DateOfBirth.Should().BeSameDateAs(command.DateOfBirth);
        }

        [Test]
        public async Task ShouldFailToCreateAUserWithoutUserId()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                FirstName = "Barry",
                DateOfBirth = DateTime.Now
            };

            // Act & Assert
            await FluentActions.Invoking(() => SendAsync(command))
                .Should().ThrowAsync<ValidationException>();
        }
    }
}
