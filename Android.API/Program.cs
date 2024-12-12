
using Android.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Android.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string cnStr = "Server=dpg-ctdh3bpopnds73alp6vg-a.singapore-postgres.render.com;Port=5432;Database=db_lab;Username=sa;Password=UfR0GBGiAafc59vZQJVDKD5iNMWMQUTZ;";
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(cnStr));
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
				});
			});
			var app = builder.Build();

			app.UseSwagger();
			app.UseSwaggerUI();
			app.UseCors();
			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
