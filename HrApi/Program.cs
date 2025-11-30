
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

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (IServiceScope scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<HrContext>();
                context.Database.EnsureCreated();
            }

            //app.UseAuthorization();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}
