using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AuditLog.Infra.Data.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        #region CONSTRUCTOR
        public RequestRepository(AuditLogContext ctx) : base(ctx) { }
        #endregion

        public override IQueryable<Request> GetAll()
        {
            return _db
                .Include(x => x.Application)
                .Include(x => x.Response)
                .Include(x => x.Location);
        }

        public override Request GetById(int id)
        {
            return _db
                .Include(x => x.Application)
                .Include(x => x.Response)
                .Include(x => x.Location)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
