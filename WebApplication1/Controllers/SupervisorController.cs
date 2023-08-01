using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BLL.Services;

namespace WebApplication1.Controllers
{
    public class SupervisorController : ApiController
    {
        [HttpPost]
        [Route("api/supervisor/create/project")]
        public HttpResponseMessage Create(ProjectDto obj)
        {
            try
            {
                var pro = SupervisorService.CreateProject(obj);

                if(!pro)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "Could not create project" });
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "New Project created" });

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
