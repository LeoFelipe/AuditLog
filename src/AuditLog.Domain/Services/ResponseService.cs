using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Domain.Interfaces.Services;

namespace AuditLog.Domain.Services
{
    public class ResponseService : Service<Response>, IResponseService
    {
        #region PARAMETERS
        private readonly IResponseRepository _ResponseRepository;
        #endregion

        #region CONSTRUCTOR
        public ResponseService(IResponseRepository ResponseRepository, IDomainNotificationHandler dnh, IUnitOfWork uow) : base(ResponseRepository, dnh, uow)
        {
            _ResponseRepository = ResponseRepository;
        }
        #endregion
    }
}
