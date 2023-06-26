using Core.Domain;

namespace Core.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAll();

        //public Task<IEnumerable<T>> GetRange(Func<T, bool> predicate);

        //public Task<T> GetById(Guid id);

        //public Task Add(T entity);

        //public Task Update(T entity);

        //public Task DeleteById(T entity);
    }
}
