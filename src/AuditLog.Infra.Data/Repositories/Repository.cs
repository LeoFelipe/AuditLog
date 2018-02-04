using AuditLog.Domain.Core.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AuditLog.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        #region PARAMETERS
        protected AuditLogContext _ctx;
        protected DbSet<TEntity> _db;
        #endregion

        #region CONSTRUCTOR
        protected Repository(AuditLogContext context)
        {
            _ctx = context;
            _db = _ctx.Set<TEntity>();
        }
        #endregion

        #region GET
        public virtual IQueryable<TEntity> GetAll() => _db;

        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate) => _db.Where(predicate);

        public virtual TEntity GetById(int id) => _db.Find(id);
        #endregion

        #region POST
        public virtual void Insert(TEntity obj) => _db.Add(obj);
        #endregion

        #region PUT
        public virtual void Update(TEntity obj) => _db.Update(obj);
        #endregion

        #region DELETE
        public virtual void Delete(int id) => _db.Remove(_db.Find(id));
        #endregion

        #region SAVECHANGES
        public int SaveChanges() => _ctx.SaveChanges();
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            _ctx.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
