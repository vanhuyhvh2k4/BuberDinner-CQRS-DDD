using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _menuItems = new();

        public string Name { get; }

        public string Description { get; }

        private MenuSection(MenuSectionId menuSectionId, string name, string description) : base(menuSectionId)
        {
            Name = name;
            Description = description;
        }

        public IReadOnlyList<MenuItem> Items => _menuItems.AsReadOnly();

        public static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(), name, description);
        }
    }
}

