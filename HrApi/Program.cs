using HrApi.Models;
using HrApi.Models.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HrApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtOptions = builder.Configuration.GetSection("Jwt");

            builder.Services.Configure<JwtOptions>(jwtOptions);

            builder.Services.AddControllers();

            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            builder.Services.AddDbContext<HrContext>(opt =>
            {
                opt.UseSqlite("Data Source=database.db");
            });

            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = string.Empty;
            })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<HrContext>();

            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.ExpireTimeSpan = TimeSpan.FromDays(7);
            //        options.SlidingExpiration = false;
            //        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            //        options.Cookie.HttpOnly = true;
            //        options.Cookie.SameSite = SameSiteMode.None;
            //        options.LoginPath = "/passkey/";
            //        options.LogoutPath = "/account/logout";
            //    });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    var jwtKey = builder.Configuration["Jwt:Key"];
                    if (string.IsNullOrEmpty(jwtKey))
                    {
                        throw new InvalidOperationException("JWT signing key is not configured.");
                    }

                    options.TokenValidationParameters.ValidIssuer = builder.Configuration["Jwt:Issuer"];
                    options.TokenValidationParameters.ValidAudience = builder.Configuration["Jwt:Audience"];
                    options.TokenValidationParameters.IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                });
            builder.Services.AddAuthorization();

            builder.Services.Configure<IdentityPasskeyOptions>(options =>
            {
                options.AuthenticatorTimeout = TimeSpan.FromMinutes(3);
                options.ChallengeSize = 64;
                options.AttestationConveyancePreference = "none";
                options.UserVerificationRequirement = "preferred";
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
            builder.Services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.Request | HttpLoggingFields.Response;
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var config = services.GetRequiredService<IConfiguration>();
                var context = services.GetRequiredService<HrContext>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
                var userManager = services.GetRequiredService<UserManager<User>>();

                context.Database.EnsureCreated();


                foreach (var role in Enum.GetNames<Roles>())
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }

                var adminUsername = config["Admin:Username"];
                var adminEmail = config["Admin:Email"];
                var adminPassword = config["Admin:Password"];

                if (adminUsername is null || adminEmail is null || adminPassword is null)
                    throw new Exception("Admin credentials are not set in configuration.");

                if (await userManager.FindByEmailAsync(adminEmail) is null)
                {
                    var user = new User
                    {
                        UserName = adminUsername,
                        Email = adminEmail,
                    };

                    var result = await userManager.CreateAsync(user, adminPassword);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                    }
                }
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.MapStaticAssets().ShortCircuit();
            app.MapControllers();
            app.UseCors(policy =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpLogging();

            app.Run();
        }
    }
}
