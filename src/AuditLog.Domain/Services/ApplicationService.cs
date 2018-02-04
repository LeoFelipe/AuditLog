using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Entities;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Domain.Interfaces.Services;

namespace AuditLog.Domain.Services
{
    public class ApplicationService : Service<Application>, IApplicationService
    {
        #region PARAMETERS
        private readonly IApplicationRepository _ProjectRepository;
        #endregion

        #region Constructor
        public ApplicationService(IApplicationRepository ProjectRepository, IDomainNotificationHandler dnh, IUnitOfWork uow) : base(ProjectRepository, dnh, uow)
        {
            _ProjectRepository = ProjectRepository;
        }
        #endregion
    }
}
