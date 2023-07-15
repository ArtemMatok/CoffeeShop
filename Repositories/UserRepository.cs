using Coffee.Data;
using Coffee.Models;
using Coffee.Service;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(User entity)
        {
            _context.Users.Add(entity);
            return Save();
        }

        public bool Delete(User entity)
        {
            _context.Users.Remove(entity);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User entity)
        {
            _context.Users.Update(entity);
            return Save();
        }
    }
}
