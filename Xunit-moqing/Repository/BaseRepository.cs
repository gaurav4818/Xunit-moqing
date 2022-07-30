using Microsoft.EntityFrameworkCore;
using Xunit_moqing.IRepository;
using Xunit_moqing.Models;

namespace Xunit_moqing.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal EmployeeContext _context;
        public BaseRepository(EmployeeContext context)
        {
            _context = context;
        }

        private DbSet<T> table = null;
        public void Add(T entity)
        {
            table.Add(entity);
            _context.SaveChanges();
        }

        public async void AddAsync(T entity)
        {
            await table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();   
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async void UpdateAsync(T entity)
        {
             table.Attach(entity);
             _context.Entry(entity).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }
    }
}
