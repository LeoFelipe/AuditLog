using AuditLog.Domain.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AuditLog.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        #region GET
        /// <summary>
        /// Get paginated list without filter
        /// </summary>
        /// <returns>Paginated list of Objects</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get paginated list with filter
        /// </summary>
        /// <param name="predicate">Filter applied by user</param>
        /// <returns>Paginated list of Objects</returns>
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="id">Object Identifier</param>
        /// <returns>Return a Object</returns>
        TEntity GetById(int id);
        #endregion

        #region POST
        /// <summary>
        /// Insert a new Record into Database
        /// </summary>
        /// <param name="obj">Object to Insert</param>
        void Insert(TEntity obj);
        #endregion

        #region PUT
        /// <summary>
        /// Update a Database Record
        /// </summary>
        /// <param name="obj">Object to Update</param>
        void Update(TEntity obj);
        #endregion

        #region DELETE
        /// <summary>
        /// Delete a Database Record
        /// </summary>
        /// <param name="id">Object Identifier</param>
        /// <returns>None Return</returns>
        void Delete(int id);
        #endregion

        #region COMMIT
        /// <summary>
        /// Commit a Transaction
        /// </summary>
        /// <returns>Number of records entered</returns>
        int SaveChanges();
        #endregion
    }
}
