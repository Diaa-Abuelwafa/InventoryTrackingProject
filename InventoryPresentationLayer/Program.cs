using InventoryBusinessLogicLayer.Contexts;
using InventoryBusinessLogicLayer.SeedData;
using InventoryBusinessLogicLayer.Services;
using InventoryDataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryPresentationLayer
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=inventory.db"));

            // Add Custom Services To DI Container
            builder.Services.AddScoped<IWarehouseService, WarehouseService>();

            var app = builder.Build();

            // Update DB & SeedData
            using (var Scope = app.Services.CreateScope())
            {
                var Context = Scope.ServiceProvider.GetRequiredService<AppDbContext>();

                try
                {
                    await Context.Database.MigrateAsync();

                    SeedHelper.Seed(Context);
                }
                catch(Exception Ex)
                {
                    // Handle Exception
                }
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Warehouse}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
