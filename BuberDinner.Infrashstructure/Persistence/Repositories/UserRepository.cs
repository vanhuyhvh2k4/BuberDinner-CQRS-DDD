using BuberDinner.Domain.UserAggregate;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrashstructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public UserRepository()
        {
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}

