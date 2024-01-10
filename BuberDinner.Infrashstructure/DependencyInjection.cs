using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Services;
using BuberDinner.Infrashstructure.Authentication;
using BuberDinner.Infrashstructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrashstructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrashstructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}

