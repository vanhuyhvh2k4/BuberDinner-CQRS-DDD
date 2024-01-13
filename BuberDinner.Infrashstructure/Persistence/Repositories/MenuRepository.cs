using System;

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrashstructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = new();

        private readonly BuberDinnerDbContext _dbContext;

        public MenuRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Menu menu)
        {
            _dbContext.Menus.Add(menu);

            _dbContext.SaveChanges();
        }
    }
}

