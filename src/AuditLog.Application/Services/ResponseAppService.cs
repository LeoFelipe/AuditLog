using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Domain.Interfaces.Services;
using AuditLog.Infra.CrossCutting.Bus;

namespace AuditLog.Application.Services
{
    public class ResponseAppService : AppService<ResponseVM>, IResponseAppService
    {
        #region PARAMETERS
        private readonly IResponseService _responseService;
        #endregion

        #region CONSTRUCTOR
        public ResponseAppService(IResponseService responseService, IBus bus) : base(responseService, bus)
        {
            _responseService = responseService;
        }
        #endregion
    }
}
