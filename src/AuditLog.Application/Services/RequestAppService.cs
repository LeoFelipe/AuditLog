using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Domain.Interfaces.Services;
using AuditLog.Infra.CrossCutting.Bus;

namespace AuditLog.Application.Services
{
    public class RequestAppService : AppService<RequestVM>, IRequestAppService
    {
        #region PARAMETERS
        private readonly IRequestService _requestService;
        #endregion

        #region CONSTRUCTOR
        public RequestAppService(IRequestService requestService, IBus bus) : base(requestService, bus)
        {
            _requestService = requestService;
        }
        #endregion
    }
}
