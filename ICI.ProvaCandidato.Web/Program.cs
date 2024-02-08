using ICI.ProvaCandidato.Dados;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ICI.ProvaCandidato.Web
{
    public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			using var scope = host.Services.CreateScope();
			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<DataContext>();
				await context.Database.MigrateAsync();
                await input.SeedData(context);
            }
			catch (Exception e)
			{
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "Ocorreu algum problema.");
            }

			await host.RunAsync();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
						.ConfigureWebHostDefaults(webBuilder =>
						{
							webBuilder.UseStartup<Startup>();
						});
	}
}
