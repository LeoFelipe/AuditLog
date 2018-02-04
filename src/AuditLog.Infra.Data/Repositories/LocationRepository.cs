using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Infra.Data.Context;

namespace AuditLog.Infra.Data.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        #region CONSTRUCTOR
        public LocationRepository(AuditLogContext ctx) : base(ctx) { }
        #endregion
    }
}
