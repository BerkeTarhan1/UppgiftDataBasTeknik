using Assignment_01.Contexts;
using Assignment_01.Entities;

namespace Assignment_01.Repositories;

internal class DeviceCategoryRepository : Repo<DeviceCategoryEntity>
{
    public DeviceCategoryRepository(DataContext context) : base(context)
    {
    }
}
