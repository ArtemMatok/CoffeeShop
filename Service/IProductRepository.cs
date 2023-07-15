using Coffee.Models;

namespace Coffee.Service
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int? id);
        Task<Product> GetByName(string name);
        Task<Product> GetByIdAlso(int id);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();
    }
}
