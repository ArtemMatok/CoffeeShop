namespace Coffee.Service
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
