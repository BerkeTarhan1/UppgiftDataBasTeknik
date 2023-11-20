using Assignment_01.Contexts;
using Assignment_01.Entities;

namespace Assignment_01.Repositories;

internal class CurrencyUnitRepository : Repo<CurrencyUnitEntity>
{
    public CurrencyUnitRepository(DataContext context) : base(context)
    {
    }
}
