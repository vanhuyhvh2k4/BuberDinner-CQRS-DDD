using System;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Guest
{
	public class Guest : AggregateRoot<GuestId>
	{
		public Guest(GuestId guestId) : base(guestId)
		{
		}
	}
}

