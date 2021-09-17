using System.Threading.Tasks;
using NUnit.Framework;

namespace Flatties.Matching.Application.Tests
{
    using static Global;

    public class TestBase
    {
        [SetUp]
        public async Task Setup()
        {
            await ResetState();
        }
    }
}
