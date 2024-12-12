using Android.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Android.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly DataContext _context;
		public EmployeeController(DataContext context)
		{
			_context = context;
		}

		public class EmployeeAddOrUpdate
		{
			public string fullName { get; set; }
			public string email { get; set; }
			public string phone { get; set; }
			public string department { get; set; }
			public decimal salary { get; set; }
		}

		[HttpGet]
		public async Task<IActionResult> Get(int? skip = null,int? take = null)
		{
			var query = _context.Employees.OrderByDescending(s => s.createdDate).AsNoTracking();

			if (skip != null && skip > 0)
			{
				query = query.Skip(skip.Value);
			}

			if (take != null && take > 0)
			{
				query = query.Take(take.Value);
			}

			return Ok(await query.ToListAsync());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var employee = await _context.Employees.FindAsync(id);
			if (employee == null)
			{
				return NotFound($"Employee with id: {id} not found");
			}
			_context.Remove(employee);
			await _context.SaveChangesAsync();
			return Ok(employee);
		} 

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeAddOrUpdate request)
		{
			var employee = await _context.Employees.FindAsync(id);
			if(employee == null)
			{
				return NotFound($"Employee with id: {id} not found");
			}
			employee.fullName = request.fullName;
			employee.email = request.email;
			employee.phone = request.phone;
			employee.department = request.department;
			employee.salary = request.salary;
			_context.Employees.Update(employee);

			await _context.SaveChangesAsync();
			return Ok(employee);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EmployeeAddOrUpdate request)
		{
			var employee = new Employee();
			employee.fullName = request.fullName;
			employee.email = request.email;
			employee.phone = request.phone;
			employee.department = request.department;
			employee.salary = request.salary;
			_context.Employees.Add(employee);

			await _context.SaveChangesAsync();
			return Ok(employee);
		}
	}
}
