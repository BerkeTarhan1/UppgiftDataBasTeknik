using Assignment_01.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_01.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<DeviceEntity> Devices { get; set; }
    public DbSet<DeviceCategoryEntity> DeviceCategories { get; set; }
    public DbSet<CurrencyUnitEntity> CurrencyUnits { get; set; }
}
