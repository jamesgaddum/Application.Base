using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Application.Base.WebAPI
{
    public static class DependencyInjection
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFirebaseAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var firebaseProjectId = configuration["FirebaseProjectId"];

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"https://securetoken.google.com/{firebaseProjectId}";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = $"https://securetoken.google.com/{firebaseProjectId}",
                        ValidateAudience = true,
                        ValidAudience = firebaseProjectId,
                        ValidateLifetime = true
                    };
                });

            return services;
        }
    }
}
