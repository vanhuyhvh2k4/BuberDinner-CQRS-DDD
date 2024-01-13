using System;

using BuberDinner.Domain.Common.Models;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuberDinner.Infrashstructure.Persistence.Interceptors
{
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _mediator;

        public PublishDomainEventsInterceptor(IPublisher mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await PublishDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainEvents(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }
            // get hold of all the various entities
            var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();
            // get hold of all domain events
            var domainEvents = entitiesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();
            // clear domain events
            entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvent());
            // publish domain event
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}

