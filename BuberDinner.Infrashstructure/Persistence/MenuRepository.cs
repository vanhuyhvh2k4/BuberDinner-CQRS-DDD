using System;

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrashstructure.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private static readonly List<Menu> _menus = new();

        public MenuRepository()
        {
        }

        public void Add(Menu menu)
        {
            _menus.Add(menu);
        }
    }
}

