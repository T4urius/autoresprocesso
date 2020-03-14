using SW.ProcessoSeletivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Domain.Contracts.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> Get();
        TEntity Get(object id);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(object id);
    }

    public interface IWriteRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
