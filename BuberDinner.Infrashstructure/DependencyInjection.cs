﻿using System.Text;

using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrashstructure.Authentication;
using BuberDinner.Infrashstructure.Persistence;
using BuberDinner.Infrashstructure.Persistence.Interceptors;
using BuberDinner.Infrashstructure.Persistence.Repositories;
using BuberDinner.Infrashstructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrashstructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrashstructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuth(configuration)
                    .AddPersistence(configuration);

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<BuberDinnerDbContext>(options => options.UseMySql(configuration.GetConnectionString("Default"), new MySqlServerVersion(new Version(10, 4, 25))));

            services.AddScoped<PublishDomainEventsInterceptor>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IMenuRepository, MenuRepository>();

            return services;
        }

            public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(
                defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}

