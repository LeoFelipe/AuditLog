using AuditLog.Application.ViewModels.ApiResponses;
using AuditLog.Infra.CrossCutting.Bus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AuditLog.Services.EP
{
    public abstract class EPBase
    {
        #region PARAMETERS
        private readonly IBus _bus;
        #endregion

        #region CONSTRUCTOR
        protected EPBase(IBus bus)
        {
            _bus = bus;
        }
        #endregion

        #region IS VALID OPERATION
        protected bool IsValidOperation() => (!_bus.HasInMemoryBusNotifications());
        #endregion

        #region RESPONSE
        public JsonResult Response(object result = null)
        {
            if (IsValidOperation())
            {
                return new JsonResult(new ResponseSuccessVM
                {
                    Success = true,
                    Data = result
                });
            }

            return new JsonResult(new ResponseErrorsVM
            {
                Success = false,
                Info = "Some errors were encountered during the request.",
                Errors = _bus.GetInMemoryBusNotifications().Select(n => n.ErrorMessage)
            });
        }
        #endregion
    }
}
