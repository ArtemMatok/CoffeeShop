using Coffee.Data;
using Coffee.Migrations;
using Coffee.Service;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Models.Order entity)
        {
            _context.Orders.Add(entity);
            return Save();
        }

        public bool Delete(Models.Order entity)
        {
            _context.Orders.Remove(entity);
            return Save();
        }

        public async Task<IEnumerable<Models.Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Models.Order> GetById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Models.Order entity)
        {
            _context.Orders.Update(entity);
            return Save();
        }
    }
}
