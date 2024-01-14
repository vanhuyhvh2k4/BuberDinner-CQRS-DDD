using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrashstructure.Persistence.Configurations
{
    public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            ConfigureDinnersTable(builder);

            ConfigureReservationsTable(builder);
        }

        private void ConfigureReservationsTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.OwnsMany(d => d.Reservations, reservationBuilder =>
            {
                reservationBuilder.ToTable("Reservations");

                reservationBuilder
                    .WithOwner()
                    .HasForeignKey("DinnerId");

                reservationBuilder
                    .Property(reservationBuilder => reservationBuilder.Id)
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => ReservationId.Create(value));

                reservationBuilder.Property(reservationBuilder => reservationBuilder.GuestCount);

                reservationBuilder.Property(reservationBuilder => reservationBuilder.ReservationStatus);

                reservationBuilder
                    .Property(reservationBuilder => reservationBuilder.GuestId)
                    .HasConversion(id => id.Value, value => GuestId.Create(value));

                reservationBuilder
                    .Property(reservationBuilder => reservationBuilder.BillId)
                    .HasConversion(id => id.Value, value => BillId.Create(value));

                reservationBuilder
                    .Property(reservationBuilder => reservationBuilder.ArrivalDateTime)
                    .IsRequired(false);
            });

            builder.Metadata
                .FindNavigation(nameof(Dinner.Reservations))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.ToTable("Dinners");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => DinnerId.Create(value));

            builder.Property(d => d.Name)
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .HasMaxLength(100);

            builder.Property(d => d.StartDateTime);

            builder.Property(d => d.EndDateTime);

            builder.Property(d => d.StartedDateTime)
                .IsRequired(false);

            builder.Property(d => d.EndedDateTime)
                .IsRequired(false);

            builder.Property(d => d.Status)
                .HasMaxLength(25);

            builder.Property(d => d.IsPublic);

            builder.Property(d => d.MaxGuest);

            builder.OwnsOne(d => d.Price);

            builder.Property(d => d.HostId)
                .HasConversion(id => id.Value, value => HostId.Create(value));

            builder.Property(d => d.MenuId)
                .HasConversion(id => id.Value, value => MenuId.Create(value));

            builder.Property(d => d.ImageUrl);

            builder.OwnsOne(d => d.Location);
        }
    }
}

