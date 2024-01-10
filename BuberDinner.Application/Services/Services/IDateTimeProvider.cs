namespace BuberDinner.Application.Services.Services
{
	public interface IDateTimeProvider
	{
		DateTime UtcNow { get; }
	}
}

