using Microsoft.EntityFrameworkCore;
using VKTaskOne.Entities.Concrete;

public class UserDbContext : DbContext
{
	public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
	public DbSet<UserGroup> UserGroups { get; set; }
	public DbSet<UserState> UserStates { get; set; }

}