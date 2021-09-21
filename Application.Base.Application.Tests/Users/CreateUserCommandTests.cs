using System;
using System.Threading.Tasks;
using Application.Base.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Application.Base.Application.Tests
{
    using static Global;

    public class CreateUserCommandTests : TestBase
    {
        [Test]
        public async Task ShouldCreateAValidUser()
        {
            // Arrange
            var externalUserId = new UserId(Guid.NewGuid().ToString());
            var command = new CreateUserCommand
            {
                Id = externalUserId,
                FirstName = "Barry",
                LastName = "Madgwick",
                DateOfBirth = DateTime.Now
            };

            var query = new GetUserQuery
            {
                Id = externalUserId
            };

            // Act
            await SendAsync(command);
            var response = await SendAsync(query);

            // Assert
            response.FirstName.Should().BeEquivalentTo(command.FirstName);
            response.LastName.Should().BeEquivalentTo(command.LastName);
            response.DateOfBirth.Should().BeSameDateAs(command.DateOfBirth.Value);
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

        [Test]
        public async Task ShouldFailToCreateAUserWithoutAFirstName()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Id = new UserId(Guid.NewGuid().ToString()),
                DateOfBirth = DateTime.Now
            };

            // Act & Assert
            await FluentActions.Invoking(() => SendAsync(command))
                .Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldFailToCreateAUserWithoutADateOfBirth()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Id = new UserId(Guid.NewGuid().ToString()),
                FirstName = "Barry"
            };

            // Act & Assert
            await FluentActions.Invoking(() => SendAsync(command))
                .Should().ThrowAsync<ValidationException>();
        }
    }
}
