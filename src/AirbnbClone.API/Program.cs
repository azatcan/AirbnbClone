
using Airbnb.Domain.Abstract;
using Airbnb.Domain.Concrete;
using Airbnb.Domain.Data;
using Airbnb.Infrastructure.Abstract;
using Airbnb.Infrastructure.Concrete;
using JWTExample.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AirbnbClone.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<DataContext>(conf => conf.UseSqlServer(builder.Configuration.GetConnectionString("DefalutConnection")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            AddOptions(builder);
            ConfigureAuth(builder);
            RegisterServices(builder);
            RegisterRepositories(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void AddOptions(WebApplicationBuilder builder)
        {
            builder.Services.AddOptions<JwtOption>().BindConfiguration("Auth");
        }

        private static void ConfigureAuth(WebApplicationBuilder builder)
        {
            var settings = builder.Configuration.GetSection("Auth").Get<JwtOption>();
            ArgumentNullException.ThrowIfNull(settings);

            builder.Services.AddAuthentication(k =>
            {
                k.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                k.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(p =>
            {
                p.IncludeErrorDetails = true;
                p.SaveToken = true;
                p.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = settings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                    ValidateLifetime = true
                };
            });
        }

        private static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<PlaceToRentService, PlaceToRentManager>();
            builder.Services.AddScoped<CityService, CityManager>();
            builder.Services.AddScoped<CategoryService, CategoryManager>();
            builder.Services.AddScoped<CommentService, CommentManager>();
            builder.Services.AddScoped<CountryService, CountryManager>();
            builder.Services.AddScoped<DistrictService, DistrictManager>();
            builder.Services.AddScoped<ImagesService, ImagesManager>();
            builder.Services.AddScoped<ÝnstitutionalService, ÝnstitutionalManager>();
            builder.Services.AddScoped<UserService, UserManager>();
        }

        private static void RegisterRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlaceToRentRepository, PlaceToRentRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
            builder.Services.AddScoped<IÝnstitutionalRepository, ÝnstitutionalRepesitory>();
            builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }
    }

}