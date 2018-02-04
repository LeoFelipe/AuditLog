using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Infra.CrossCutting.Bus;
using AuditLog.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AuditLog.Services.EP
{
    public class Log : EPBase
    {
        #region PARAMETERS
        private ServiceCollection services = new ServiceCollection();
        #endregion

        #region CONSTRUCTOR
        public Log(IBus bus) : base(bus)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
        #endregion

        public JsonResult Request(RequestVM request)
        {
            var requestServise = services.BuildServiceProvider().GetService<IRequestAppService>();
            return Response(requestServise.Insert(request));
        }
    }
}
