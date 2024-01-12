using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; }

        public string Address { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        private Location(string name, string address, double latitude, double longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Location CreateNew(
            string name,
            string address,
            double latitude,
            double longitude)
        {
            return new(
                name,
                address,
                latitude,
                longitude);
        }

        public override IEnumerable<object> GetEqualtityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}

