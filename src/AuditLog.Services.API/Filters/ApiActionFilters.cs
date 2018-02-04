using AuditLog.Application.ViewModels.ApiResponses;
using AuditLog.Infra.CrossCutting.Bus;
using AuditLog.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;

namespace AuditLog.Services.API.Filters
{
    public sealed class ApiActionFilters : IActionFilter
    {
        #region PARAMETERS
        private IBus _bus;
        #endregion

        #region CREATE INSTANCES
        private void CreateInstances()
        {
            var services = new ServiceCollection();
            NativeInjectorBootStrapper.RegisterServices(services);
            _bus = services.BuildServiceProvider().GetService<IBus>();
        }
        #endregion

        #region ON ACTION EXECUTED
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        #endregion

        #region ON ACTION EXECUTING
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                CreateInstances();
                var erros = context.ModelState.Values.SelectMany(v => v.Errors);
                foreach (var erro in erros)
                {
                    var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    _bus.SetNotification(string.Empty, erroMsg);
                }

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorsVM
                {
                    Success = false,
                    Info = "Some errors were encountered during the request.",
                    Errors = _bus.GetInMemoryBusNotifications().Select(n => n.ErrorMessage)
                });
            }
        }
        #endregion
    }
}
