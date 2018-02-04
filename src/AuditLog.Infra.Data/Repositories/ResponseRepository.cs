using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AuditLog.Infra.Data.Repositories
{
    public class ResponseRepository : Repository<Response>, IResponseRepository
    {
        #region CONSTRUCTOR
        public ResponseRepository(AuditLogContext ctx) : base(ctx) { }
        #endregion

        public override IQueryable<Response> GetAll()
        {
            return _db.Include(x => x.Request).ThenInclude(x => x.Application);
        }

        public override Response GetById(int id)
        {
            return _db.Include(x => x.Request).ThenInclude(x => x.Application).FirstOrDefault(x => x.Id == id);
        }
    }
}
