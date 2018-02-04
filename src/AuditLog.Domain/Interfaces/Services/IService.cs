using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AuditLog.Domain.Interfaces.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        #region GET
        /// <summary>
        /// Get paginated list without filter
        /// </summary>
        /// <returns>Paginated list of Objects</returns>
        List<TEntity> GetAll();

        /// <summary>
        /// Get paginated list with filter
        /// </summary>
        /// <param name="filter">Filter applied by user</param>
        /// <returns>Paginated list of Objects</returns>
        List<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);

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
        TEntity Insert(TEntity obj);
        #endregion

        #region PUT
        /// <summary>
        /// Update a Database Record
        /// </summary>
        /// <param name="obj">Object to Update</param>
        TEntity Update(TEntity obj);
        #endregion

        #region DELETE
        /// <summary>
        /// Delete a Database Record
        /// </summary>
        /// <param name="id">Object Identifier</param>
        /// <returns>None Return</returns>
        void Delete(int id);
        #endregion
    }
}
