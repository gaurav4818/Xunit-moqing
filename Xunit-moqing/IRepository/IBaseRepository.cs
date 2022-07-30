namespace Xunit_moqing.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void AddAsync(T entity);
        void Update(T entity);
        void UpdateAsync(T entity);
        void Delete(T entity);
        T GetById (int id);
        Task<T> GetByIdAsync (int id);

    }
}
