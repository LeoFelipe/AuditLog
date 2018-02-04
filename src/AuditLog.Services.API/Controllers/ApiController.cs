using AuditLog.Application.ViewModels.ApiResponses;
using AuditLog.Infra.CrossCutting.Bus;
using AuditLog.Services.API.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace AuditLog.Services.API.Controllers
{
    [ServiceFilter(typeof(ApiActionFilters))]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    public abstract class ApiController : Controller
    {
        #region PARAMETERS
        private readonly IBus _bus;
        #endregion

        #region CONSTRUCTOR
        protected ApiController(IBus bus)
        {
            _bus = bus;
        }
        #endregion

        #region IS VALID OPERATION
        protected bool IsValidOperation() => (!_bus.HasInMemoryBusNotifications());
        #endregion

        #region RESPONSE
        public new ActionResult Response(HttpStatusCode statusCode, object result = null)
        {
            if (IsValidOperation())
            {
                if (statusCode == HttpStatusCode.NoContent)
                {
                    return NoContent();
                }

                if (statusCode == HttpStatusCode.Created)
                {
                    return Created("", new ResponseSuccessVM
                    {
                        Success = true,
                        Data = result
                    });
                }

                return Ok(new ResponseSuccessVM
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new ResponseErrorsVM
            {
                Success = false,
                Info = "Some errors were encountered during the request.",
                Errors = _bus.GetInMemoryBusNotifications().Select(n => n.ErrorMessage)
            });
        }
        #endregion
    }
}
