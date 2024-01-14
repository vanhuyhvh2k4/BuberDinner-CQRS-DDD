using BuberDinner.Domain.UserAggregate;
using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrashstructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BuberDinnerDbContext _context;

        public UserRepository(BuberDinnerDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}

