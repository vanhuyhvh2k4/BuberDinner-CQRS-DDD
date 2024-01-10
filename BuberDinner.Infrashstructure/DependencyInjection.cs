using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrashstructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrashstructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrashstructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}

