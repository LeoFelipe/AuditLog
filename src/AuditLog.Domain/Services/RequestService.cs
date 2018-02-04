using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Domain.Interfaces.Services;

namespace AuditLog.Domain.Services
{
    public class RequestService : Service<Request>, IRequestService
    {
        #region PARAMETERS
        private readonly IRequestRepository _RequestRepository;
        #endregion

        #region CONSTRUCTOR
        public RequestService(IRequestRepository RequestRepository, IDomainNotificationHandler dnh, IUnitOfWork uow) : base(RequestRepository, dnh, uow)
        {
            _RequestRepository = RequestRepository;
        }
        #endregion
    }
}
