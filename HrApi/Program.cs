
using HrApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HrApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            builder.Services.AddDbContext<HrContext>(opt =>
            {
                opt.UseSqlite("Data Source=database.db");
            });

            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<HrContext>();

            builder.Services.Configure<IdentityPasskeyOptions>(options =>
            {
                options.AuthenticatorTimeout = TimeSpan.FromMinutes(3);
                options.ChallengeSize = 64;
                options.UserVerificationRequirement = "required";
                options.ResidentKeyRequirement = "preferred";
                options.AuthenticatorAttachment = "platform";
                options.ValidateOrigin = async (context) =>
                {
                    var origin = context.Origin;
                    var request = context.HttpContext.Request;

                    if (origin == $"https://{request.Host.Host}:{request.Host.Port}")
                        return true;
                    else
                        return false;
                };
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<HrContext>();
                context.Database.EnsureCreated();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
