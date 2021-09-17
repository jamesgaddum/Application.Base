using System;
using System.Threading.Tasks;
using Flatties.Matching.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Flatties.Matching.Application.Tests.Users
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
                FirebaseUid = Guid.NewGuid().ToString(),
                FirstName = "Barry",
                LastName = "Madgewick",
                DateOfBirth = DateTime.Now
            };

            await AddAsync(user);

            var query = new GetUserQuery
            {
                FirebaseUid = user.FirebaseUid
            };

            // Act
            var response = await SendAsync(query);

            // Assert
            response.FirebaseUid.Should().BeEquivalentTo(user.FirebaseUid);
            response.FirstName.Should().BeEquivalentTo(user.FirstName);
            response.LastName.Should().BeEquivalentTo(user.LastName);
            response.DateOfBirth.Should().BeSameDateAs(user.DateOfBirth);
        }
    }
}
