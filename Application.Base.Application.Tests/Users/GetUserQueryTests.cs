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
            var userDto = UserDto.MapFrom(new User(
                id: Guid.NewGuid().ToString(),
                firstName: "Barry",
                lastName: "Madgewick",
                dateOfBirth: DateTime.Now
            ));

            await AddAsync(userDto);

            var query = new GetUserQuery(userDto.Id);

            // Act
            var response = await SendAsync(query);

            // Assert
            response.Id.Should().BeEquivalentTo(userDto.Id);
            response.FirstName.Should().BeEquivalentTo(userDto.FirstName);
            response.LastName.Should().BeEquivalentTo(userDto.LastName);
            response.DateOfBirth.Should().BeSameDateAs(userDto.DateOfBirth);
        }
    }
}
