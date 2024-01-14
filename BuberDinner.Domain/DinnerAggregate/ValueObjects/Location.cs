using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; private set; }

        public string Address { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

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

