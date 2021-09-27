using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Application.Base.WebAPI
{
    public static class DependencyInjection
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFirebaseAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://securetoken.google.com/base-app-9e8d3";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/base-app-9e8d3",
                        ValidateAudience = true,
                        ValidAudience = "base-app-9e8d3",
                        ValidateLifetime = true
                    };
                });

            return services;
        }
    }
}
