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

        [HttpPost]
        [Route("api/supervisor/confirm/project/{id}")]
        public HttpResponseMessage ConfirmProject(int id)
        {
            try
            {
                var state = SupervisorService.ConfirmProject(id);
                if(!state)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "Invalid Request" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Confirmed" });
                }

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/supervisor/open/project")]
        public HttpResponseMessage Get()
        {
            var data = SupervisorService.Get();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/supervisor/in-progress/project")]
        public HttpResponseMessage GetInProgress()
        {
            var data = SupervisorService.GetInProgress();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }



        [HttpGet]
        [Route("api/supervisor/ip/project")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = SupervisorService.ViewProgress(id);
                if(data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "No data found" }); 
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
