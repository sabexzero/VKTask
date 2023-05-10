using VKTaskOne.Entities.Concrete;

namespace VKTaskOne.Services.Abstract;
public interface IUserService
{
    Task CreateUser(User entity);
    Task<bool> DeleteUser(Guid id);
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUser(Guid id);
    Task<bool> UpdateUser (User entity);
    Task SaveChanges();
}