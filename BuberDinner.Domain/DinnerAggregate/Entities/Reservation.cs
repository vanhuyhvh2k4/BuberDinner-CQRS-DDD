using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; private set; }

        public string ReservationStatus { get; private set; }

        public GuestId GuestId { get; private set; }

        public BillId BillId { get; private set; }

        public DateTime? ArrivalDateTime { get; private set; }

        public DateTime CreatedDateTime { get; private set; }

        public DateTime UpdatedDateTime { get; private set; }

        private Reservation(
            ReservationId reservationId,
            int guestCount,
            string reservationStatus,
            GuestId guestId,
            BillId billId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Reservation Create(
            int guestCount,
            string reservationStatus,
            GuestId guestId,
            BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                reservationStatus,
                guestId,
                billId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

#pragma warning disable CS8618
        private Reservation() { }
#pragma warning restore CS8618
    }
}

