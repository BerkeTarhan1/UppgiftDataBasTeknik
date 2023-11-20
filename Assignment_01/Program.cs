using Assignment_01.Contexts;
using Assignment_01.Menus;
using Assignment_01.Repositories;
using Assignment_01.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment_01;

internal class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Berke\\Desktop\\skola\\Databasteknik\\Inlämningsuppgfit_01\\Assignment_01\\Contexts\\Assignment_database.mdf;Integrated Security=True;Connect Timeout=30"));

        //Repositories
        services.AddScoped<AddressRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<CurrencyUnitRepository>();
        services.AddScoped<DeviceCategoryRepository>();
        services.AddScoped<DeviceRepository>();

        //Services
        services.AddScoped<UserService>();
        services.AddScoped<DeviceService>();


        //Menus
        services.AddScoped<UserMenu>();
        services.AddScoped<DeviceMenu>();
        services.AddScoped<MainMenu>();

        var sp = services.BuildServiceProvider();
        var mainMenu = sp.GetRequiredService<MainMenu>();
        await mainMenu.StartAsync();
    }
}