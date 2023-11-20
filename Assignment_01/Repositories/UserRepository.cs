using Assignment_01.Contexts;
using Assignment_01.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment_01.Repositories;

internal class UserRepository : Repo<UserEntity>
{
    private readonly DataContext _context;
    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.Include(x => x.Address).ToListAsync();
        
    }
}
