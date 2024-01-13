using System;

using BuberDinner.Domain.MenuAggregate;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrashstructure.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        public BuberDinnerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);
                 base.OnModelCreating(modelBuilder);
        }
    }
}

