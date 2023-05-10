using Microsoft.EntityFrameworkCore;
using VKTaskOne.Entities.Concrete;
using VKTaskOne.Data.Repositories.Concrete;
using VKTaskOne.Services.Abstract;
using VKTaskOne.Data.Repositories.Abstract;

namespace VKTaskOne.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        public UserService(IBaseRepository<User> repos)
        {
            _repository = repos;
        }
        public async Task CreateUser(User entity)
        {
            await _repository.Create(entity);
        }
        public async Task<bool> UpdateUser(User entity)
        {
            return await _repository.Update(entity);
        }
        public async Task<bool> DeleteUser(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAll();
        }

        public async Task<User> GetUser(Guid id)
        {
            return await _repository.Get(id);
        }
        public async Task SaveChanges()
        {
            await _repository.Save();
        }
    }
}
