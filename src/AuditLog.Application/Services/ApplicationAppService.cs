using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Domain.Interfaces.Services;
using AuditLog.Infra.CrossCutting.Bus;

namespace AuditLog.Application.Services
{
    public class ApplicationAppService : AppService<ApplicationVM>, IApplicationAppService
    {
        #region PARAMETERS
        private readonly IApplicationService _applicationService;
        #endregion

        #region CONSTRUCTOR
        public ApplicationAppService(IApplicationService applicationService, IBus bus) : base(applicationService, bus)
        {
            _applicationService = applicationService;
        }
        #endregion
    }
}
