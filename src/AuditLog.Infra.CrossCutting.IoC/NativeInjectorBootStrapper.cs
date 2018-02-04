using AuditLog.Application.Interfaces;
using AuditLog.Application.Services;
using AuditLog.Domain.Core.Interfaces;
using AuditLog.Domain.Core.Notifications;
using AuditLog.Domain.Interfaces.Repositories;
using AuditLog.Domain.Interfaces.Services;
using AuditLog.Domain.Services;
using AuditLog.Infra.CrossCutting.Bus;
using AuditLog.Infra.Data.Context;
using AuditLog.Infra.Data.Repositories;
using AuditLog.Infra.Data.UoW;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AuditLog.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region APPLICATION
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IRequestAppService, RequestAppService>();
            services.AddScoped<IResponseAppService, ResponseAppService>();
            services.AddScoped<IApplicationAppService, ApplicationAppService>();
            #endregion

            #region DOMAIN
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            #endregion

            #region INFRA
            services.AddScoped<AuditLogContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBus, InMemoryBus>();

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IResponseRepository, ResponseRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            #endregion
        }
    }
}
