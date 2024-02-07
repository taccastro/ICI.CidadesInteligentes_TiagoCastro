using ICI.ProvaCandidato.Dados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace ICI.ProvaCandidato.Web
{
    public class Startup
	{
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

  //      public Startup(IConfiguration configuration)
		//{
		//	Configuration = configuration;
		//}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddDbContext<DataContext>(opt =>
			{
				opt.UseSqlite(_config.GetConnectionString("DefaultConnection"));
			});

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var ptBrCulture = new CultureInfo("pt-BR");
                options.DefaultRequestCulture = new RequestCulture(ptBrCulture);
                options.SupportedCultures = new[] { ptBrCulture };
                options.SupportedUICultures = new[] { ptBrCulture };
            });
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
			});

            app.UseRequestLocalization();
        }
	}
}
