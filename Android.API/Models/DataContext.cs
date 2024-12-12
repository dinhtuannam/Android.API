using Microsoft.EntityFrameworkCore;

namespace Android.API.Models;

public class DataContext : DbContext
{
	public DbSet<Employee> Employees { get; set; }
	public DataContext(DbContextOptions<DataContext> options): base(options) {}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
