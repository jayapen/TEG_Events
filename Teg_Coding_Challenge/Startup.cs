using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Teg_Coding_Challenge;

namespace YourNamespace
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Web API services
            services.AddControllers();

            // Add Razor Pages services
            services.AddRazorPages();
            services.AddSingleton<Globals>();

            // Configure any additional services for your API or Razor Pages if needed
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // Configure routing for the API and Razor Pages
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // For Web API controllers
                endpoints.MapRazorPages();   // For Razor Pages
            });
        }
    }
}
