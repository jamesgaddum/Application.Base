using System;
using System.Threading.Tasks;
using Application.Base.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Application.Base.Application.Tests.Users
{
    using static Global;

    public class GetUserQueryTests
    {
        [Test]
        public async Task ShouldFetchValidUser()
        {
            // Arrange
            var user = new User
            {
                Id = new UserId(Guid.NewGuid().ToString()),
                FirstName = "Barry",
                LastName = "Madgewick",
                DateOfBirth = DateTime.Now
            };

            await AddAsync(user);

            var query = new GetUserQuery
            {
                Id = user.Id
            };

            // Act
            var response = await SendAsync(query);

            // Assert
            response.Id.Should().BeEquivalentTo(user.Id);
            response.FirstName.Should().BeEquivalentTo(user.FirstName);
            response.LastName.Should().BeEquivalentTo(user.LastName);
            response.DateOfBirth.Should().BeSameDateAs(user.DateOfBirth);
        }
    }
}
