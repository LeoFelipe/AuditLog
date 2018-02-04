using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Infra.CrossCutting.Bus;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuditLog.Services.API.Controllers
{
    [Route("log-requests")]
    public class RequestsController : ApiController
    {
        #region PARAMETERS
        private readonly IRequestAppService _responseAppService;
        #endregion

        #region CONSTRUCTOR
        public RequestsController(IRequestAppService requestAppService, IBus bus) : base(bus)
        {
            _responseAppService = requestAppService;
        }
        #endregion

        [HttpGet]
        public IActionResult Get()
        {
            return Response(HttpStatusCode.OK, _responseAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(HttpStatusCode.OK, _responseAppService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]RequestVM obj)
        {
            return Response(HttpStatusCode.Created, _responseAppService.Insert(obj));
        }
    }
}
