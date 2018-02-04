using AuditLog.Application.Interfaces;
using AuditLog.Application.ViewModels;
using AuditLog.Infra.CrossCutting.Bus;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuditLog.Services.API.Controllers
{
    [Route("[controller]")]
    public class ApplicationsController : ApiController
    {
        #region PARAMETERS
        private readonly IApplicationAppService _applicationAppService;
        #endregion

        #region CONSTRUCTOR
        public ApplicationsController(IApplicationAppService applicationAppService, IBus bus) : base(bus)
        {
            _applicationAppService = applicationAppService;
        }
        #endregion

        // GET api/v1/applications
        /// <summary>
        /// List All Applications
        /// </summary>
        /// <returns>List of Applications</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Response(HttpStatusCode.OK, _applicationAppService.GetAll());
        }

        // GET api/v1/applications/5
        /// <summary>
        /// Get Application By ID
        /// </summary>
        /// <param name="id">Application's ID</param>
        /// <returns>Application Object</returns>
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(HttpStatusCode.OK, _applicationAppService.GetById(id));
        }

        // POST api/v1/applications
        /// <summary>
        /// Save a Application
        /// </summary>
        /// <param name="obj">Object of Application to save</param>
        /// <returns>Application saved</returns>
        [HttpPost]
        public IActionResult Post([FromBody]ApplicationVM obj)
        {
            return Response(HttpStatusCode.Created, _applicationAppService.Insert(obj));
        }

        // PUT api/v1/applications/5
        /// <summary>
        /// Update an Application
        /// </summary>
        /// <param name="obj">Object of Application to Update</param>
        /// <returns>Application Updated</returns>
        [HttpPut]
        public IActionResult Put([FromBody]ApplicationVM obj)
        {
            return Response(HttpStatusCode.OK, _applicationAppService.Update(obj));
        }

        // DELETE api/v1/applications/5
        /// <summary>
        /// Delete an Application
        /// </summary>
        /// <param name="id">Application's ID</param>
        /// <returns>No Content</returns>
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _applicationAppService.Delete(id);
            return Response(HttpStatusCode.NoContent);
        }
    }
}
