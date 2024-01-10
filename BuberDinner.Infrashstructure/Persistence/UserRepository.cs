﻿using System;
using BuberDinner.Application.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrashstructure.Persistence
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
