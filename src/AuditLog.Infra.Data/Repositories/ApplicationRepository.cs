using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AuditLog.Infra.Data.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        #region CONSTRUCTOR
        public ApplicationRepository(AuditLogContext ctx) : base(ctx) { }
        #endregion

        public override IQueryable<Application> GetAll()
        {
            return _db
                .Include(x => x.Requests).ThenInclude(y => y.Response)
                .Include(x => x.Requests).ThenInclude(y => y.Location);
        }

        public override Application GetById(int id)
        {
            return _db
                .Include(x => x.Requests).ThenInclude(y => y.Response)
                .Include(x => x.Requests).ThenInclude(y => y.Location)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
