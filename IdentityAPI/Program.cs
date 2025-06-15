using Identity.Service;
using IdentityAPI.Services;
using IdentityAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Serilog;

namespace IdentityAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(builder.Configuration)
                                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<UserContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("postgres")));

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRequestService, RequestService>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v3", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Identity API",
                    Version = "v3",
                    Description = "API for Identity, a social media platform for sharing chirps.",
                });
            });

            

            var app = builder.Build();

            app.UseSwagger(c =>
            {
                c.OpenApiVersion = OpenApiSpecVersion.OpenApi3_0;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v3/swagger.json", "Identity API V1");
            });
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
