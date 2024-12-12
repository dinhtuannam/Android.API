using System.ComponentModel.DataAnnotations;

namespace Android.API.Models;

public class Employee
{
	public Employee()
	{
		id = Guid.NewGuid();
		createdDate = DateTime.Now;
	}

	[Key]
	public Guid id { get; set; }
	public string fullName { get; set; } = string.Empty;
	public string email { get; set; } = string.Empty;
	public string phone { get; set; } = string.Empty;
	public string department { get; set; } = string.Empty;
	public decimal salary { get; set; } = 0;
	public DateTime? createdDate { get; set; }
}
