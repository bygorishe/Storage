using Core.Abstractions;
using Core.Domain;

namespace Storage.MainConsole.Repositories
{
    public class LocalRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IEnumerable<T> _datas;

        public LocalRepository(IEnumerable<T> datas)
        {
            _datas = datas;
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.FromResult(_datas);
        }

        //public Task Add(T entity)
        //{
        //    _datas.Append(entity);
        //    return Task.CompletedTask;
        //}

        //public Task DeleteById(T entity)
        //{
        //    ((List<T>)_datas).Remove(entity);
        //    return Task.CompletedTask;
        //}

        //public Task<T> GetById(Guid id)
        //{
        //    return Task.FromResult(_datas.FirstOrDefault(x => x.Id == id));
        //}

        //public Task<IEnumerable<T>> GetRange(Func<T, bool> predicate)
        //{
        //    return Task.FromResult(_datas.Where(predicate));
        //}
    }
}
