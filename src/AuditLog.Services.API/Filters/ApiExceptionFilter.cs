using AuditLog.Application.ViewModels.ApiResponses;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace AuditLog.Services.API.Filters
{
    public sealed class ApiExceptionFilter : ExceptionFilterAttribute
    {
        #region PARAMETERS
        private readonly IHostingEnvironment _env;
        #endregion

        #region CONSTRUCTOR
        public ApiExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }
        #endregion

        public override void OnException(ExceptionContext context)
        {
            var apiError = new ResponseErrorsVM
            {
                Success = false,
                Info = "The system presented unexpected behavior. "
            };

            if (_env.IsDevelopment())
            {
                var info = (context.Exception.GetBaseException().Message ?? context.Exception.Message);
                apiError.Info = info.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var erros = context.Exception.StackTrace;
                apiError.Errors = erros.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                if (context.Exception is SqlException)
                {
                    apiError.Info = "The server was not found or was not accessible. ";
                }

                if (context.Exception is DbUpdateException)
                {
                    apiError.Info = "Could not save data in Database. ";
                }

                if (context.Exception is AutoMapperConfigurationException)
                {
                    apiError.Info = "Mapping Error. ";
                }

                if (context.Exception is ApplicationException)
                {
                    apiError.Info = "Some errors were encountered during the request. ";
                }

                apiError.Info += "Please try again or contact the Administrator.";

                if (!(new[] { "UI", nameof(Services), nameof(Application), nameof(Domain), nameof(Infra) }).Any(x => context.Exception.GetBaseException().Message.Contains(x)))
                {
                    var erros = context.Exception.GetBaseException().Message ?? context.Exception.Message;
                    apiError.Errors = erros.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
