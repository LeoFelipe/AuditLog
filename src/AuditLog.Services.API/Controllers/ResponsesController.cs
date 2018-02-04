using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Infra.CrossCutting.Bus;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuditLog.Services.API.Controllers
{
    [Route("log-responses")]
    public class ResponsesController : ApiController
    {
        #region PARAMETERS
        private readonly IResponseAppService _responseAppService;
        #endregion

        #region CONSTRUCTOR
        public ResponsesController(IResponseAppService ResponseAppService, IBus bus) : base(bus)
        {
            _responseAppService = ResponseAppService;
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
        public IActionResult Post([FromBody]ResponseVM obj)
        {
            return Response(HttpStatusCode.Created, _responseAppService.Insert(obj));
        }
    }
}
