using VKTaskOne.Entities.Concrete;
using VKTaskOne.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8603 // Possible null reference return.
namespace VKTaskOne.Data.Repositories.Concrete;
public class UserRepository : IBaseRepository<User>
{
    private readonly UserDbContext _context;
    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    public async Task Create(User entity)
    {
        var admin = await _context.UserGroups.FirstOrDefaultAsync(s => s.Code == GroupCode.Admin);
        int count = await _context.Users.Where(s => s.UserGroupId == admin.Id).CountAsync();
        var foundUser = await _context.Users.FirstOrDefaultAsync(s => s.Login == entity.Login);
        if (foundUser == null) 
        {
            if (count == 0 && entity.UserGroupId == admin.Id)
            {
                await _context.Set<User>().AddAsync(entity);
            }
            else
            {
                if (entity.UserGroupId != admin.Id)
                {
                    await _context.Set<User>().AddAsync(entity);
                }
                else
                {
                    throw new InvalidOperationException("Операция добавления невозможна, так как количество пользователей с ролью Администратора не должно превышать 1");
                }
            }
        }
        else
        {
            throw new InvalidOperationException("Операция добавления невозможна, так как пользователей с таким логином уже существует");
        }
    }

    public async Task<bool> Delete(Guid id)
    {
        var deleted = await _context.Set<User>().FirstOrDefaultAsync(s => s.Id == id);
        var state = await _context.Set<UserState>().FirstOrDefaultAsync(s => s.Code == StateCode.Blocked);
            if (deleted != null)
            {
                deleted.UserStateId = state.Id;
                return true;
            }
        return false;
    }

    public async Task<bool> Update(User user)
    {
        _context.Update(user);
        await Save();
        return true;
    }

    public async Task<User> Get(Guid id)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Set<User>().ToListAsync();
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}