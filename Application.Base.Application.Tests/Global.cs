using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MediatR;
using NUnit.Framework;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Application.Base.WebAPI;
using System.Threading;
using Respawn;

namespace Application.Base.Application.Tests
{
    [SetUpFixture]
    public class Global
    {
        private static IConfiguration _config;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;

        [OneTimeSetUp]
        public void RunBeforeAllTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            _config = builder.Build();

            var services = new ServiceCollection();
            var startup = new Startup(_config);
            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[] { "__EFMigrationsHistory" }
            };
        }

        public async static Task ResetState()
        {
            await _checkpoint.Reset(_config.GetConnectionString("Default"));
        }

        public static async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IApplicationDbContext>();

            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync(default(CancellationToken));
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request) where TResponse : class
        {
            using var scope = _scopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }
    }
}
