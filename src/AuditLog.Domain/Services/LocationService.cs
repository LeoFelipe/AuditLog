using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Domain.Interfaces.Services;

namespace AuditLog.Domain.Services
{
    public class LocationService : Service<Location>, ILocationService
    {
        #region PARAMETERS
        private readonly ILocationRepository _LocationRepository;
        #endregion

        #region CONSTRUCTOR
        public LocationService(ILocationRepository LocationRepository, IDomainNotificationHandler dnh, IUnitOfWork uow) : base(LocationRepository, dnh, uow)
        {
            _LocationRepository = LocationRepository;
        }
        #endregion
    }
}
