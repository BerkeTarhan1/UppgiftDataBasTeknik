using Assignment_01.Contexts;
using Assignment_01.Entities;

namespace Assignment_01.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
