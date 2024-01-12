using System;

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // 1. Create menu
            var menu = Menu.Create(
                request.Name,
                request.Description,
                HostId.Create(request.HostId),
                request.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description)))));
            // 2. Persist menu
            _menuRepository.Add(menu);

            // 3. Return menu
            return menu;
        }
    }
}

