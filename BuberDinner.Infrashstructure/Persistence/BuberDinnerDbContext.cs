using System;

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.UserAggregate;
using BuberDinner.Infrashstructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrashstructure.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

        public BuberDinnerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);
                 base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

