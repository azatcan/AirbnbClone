using Airbnb.Domain.Data;
using JWTExample.Options;
using Microsoft.EntityFrameworkCore;

namespace AirbnbClone.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(conf => conf.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection")));

            builder.Services.AddSession();
            AddOptions(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        private static void AddOptions(WebApplicationBuilder builder)
        {
            builder.Services.AddOptions<JwtOption>().BindConfiguration("Auth");
        }
    }
}