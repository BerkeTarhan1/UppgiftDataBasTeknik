using Assignment_01.Contexts;
using Assignment_01.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Assignment_01.Repositories;

internal class DeviceRepository : Repo<DeviceEntity>
{
    private readonly DataContext _context;
    public DeviceRepository (DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<DeviceEntity>> GetAllAsync()
    {
        return await   _context.Devices
            .Include(x => x.CurrencyUnit)
            .Include(x => x.DeviceCategory)
            .ToListAsync();
    }
}
