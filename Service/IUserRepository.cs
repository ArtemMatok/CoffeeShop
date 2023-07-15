using Coffee.Models;

namespace Coffee.Service
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByName(string name);
    }
}
