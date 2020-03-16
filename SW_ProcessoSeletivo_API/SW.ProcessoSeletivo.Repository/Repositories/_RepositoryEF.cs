using Microsoft.EntityFrameworkCore;
using SW.ProcessoSeletivo.Domain.Contracts.Repositories;
using SW.ProcessoSeletivo.Domain.Entities;
using SW.ProcessoSeletivo.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.ProcessoSeletivo.Repository.Repositories
{
    public class ReadRepositoryEF<TEntity> : IReadRepository<TEntity> where TEntity : Entity
    {
        protected readonly SWAutoresDataContext _ctx;
        protected readonly DbSet<TEntity> _db;

        public ReadRepositoryEF(SWAutoresDataContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _db.AsNoTracking().ToList();
        }

        public TEntity Get(object id)
        {
            return _db
                //.AsNoTracking()
                //.FirstOrDefault(d => d.Id);
                .Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await _db
                //.AsNoTracking()
                //.FirstOrDefault(d => d.Id);
                .FindAsync(id);
        }
    }

    public class WriteRepositoryEF<TEntity> : IWriteRepository<TEntity> where TEntity : Entity
    {
        private readonly SWAutoresDataContext _ctx;
        protected readonly DbSet<TEntity> _db;

        public WriteRepositoryEF(SWAutoresDataContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _ctx.Update(entity);
        }
    }
}
