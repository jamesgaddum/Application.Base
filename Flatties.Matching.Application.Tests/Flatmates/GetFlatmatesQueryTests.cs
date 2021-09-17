using System;
using System.Linq;
using System.Threading.Tasks;
using Flatties.Matching.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Flatties.Matching.Application.Tests.Flatmates
{
    using static Global;

    public class GetFlatmatesQueryTests
    {
        [Test]
        public async Task ShouldFetchAllFlatmates()
        {
            // Arrange
            var user = new User { Id = Guid.NewGuid() };
            await AddAsync(user);

            var flat = new Flat(new Flatmate[] { new Flatmate(user.Id) })
            {
                Id = Guid.NewGuid()
            };
            await AddAsync(flat);

            var query = new GetFlatmatesQuery
            {
                FlatId = flat.Id
            };

            // Act
            var response = await SendAsync(query);

            // Assert
            response.Count().Should().Be(1);
        }
    }
}
