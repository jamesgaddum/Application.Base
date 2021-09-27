using Application.Base.Persistence;
using Application.Base.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System.IO;

namespace Application.Base.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application.Base.WebAPI", Version = "v1" });

            });
            services.AddFirebaseAuthentication();
            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddValidatorsFromAssemblyContaining<IApplicationDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application.Base.WebAPI v1"));
                app.UseExceptionHandler("/dev-error");

                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile($"{Directory.GetCurrentDirectory()}/Base-App-Private-Key.json")
                });
            }
            else
            {
                app.UseExceptionHandler("/error");

                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.GetApplicationDefault()
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
