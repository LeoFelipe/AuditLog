using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AuditLog.Application.Interfaces
{
    public interface IAppService<VM> : IDisposable where VM : class
    {
        #region GET
        /// <summary>
        /// Get paginated list without filter
        /// </summary>
        /// <returns>Paginated list of Objects</returns>
        IEnumerable<VM> GetAll();

        /// <summary>
        /// Get paginated list with filter
        /// </summary>
        /// <param name="filter">Filter applied by user</param>
        /// <returns>Paginated list of Objects</returns>
        IEnumerable<VM> GetBy(Expression<Func<VM, bool>> filter);

        /// <summary>
        /// Get Entity by Id
        /// </summary>
        /// <param name="id">Object Identifier</param>
        /// <returns>Return a Object</returns>
        VM GetById(int id);
        #endregion

        #region POST
        /// <summary>
        /// Insert a new Record into Database
        /// </summary>
        /// <param name="obj">Object to Insert</param>
        /// <returns>Object Inserted</returns>
        VM Insert(VM obj);
        #endregion

        #region PUT
        /// <summary>
        /// Update a Database Record
        /// </summary>
        /// <param name="obj">Object to Update</param>
        /// <returns>Object Updated</returns>
        VM Update(VM obj);
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
