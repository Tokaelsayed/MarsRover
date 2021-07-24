using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Task_MarsRover.Controllers
{
    public class RoverController : ApiController
    {
        private static string[] ApiKeys = { "key1", "key2", "key3", "key4" };
        [HttpGet]
        public HttpResponseMessage Initialize([FromBody]string Apikey)
        {

            foreach (var key in ApiKeys)
            {
                if (key == Apikey)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, Models.Rover.AddRover());
                }
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Api Key");
        }
        [HttpGet]
        public HttpResponseMessage SetRoverPosition([FromBody]Models.SetRoverPositionRequest roverPositionRequest)
        {
            if (Models.Rover.SetRoverPosition(roverPositionRequest))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ID");
        }


        [HttpGet]
        public HttpResponseMessage AddRoverObstacles([FromBody]Models.AddObstaclesReuest addObstaclesReuest)
        {
            if (Models.Rover.AddRoverObstacles(addObstaclesReuest))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ID");
        }
        [HttpGet]
        public HttpResponseMessage RunCommand([FromBody]Models.RunCommandRequest runCommandRequest)
        {
            if(Models.Rover.CheckCommandRequestID(runCommandRequest))
            {
               
                return Request.CreateResponse(HttpStatusCode.OK, Models.RunCommandRequest.position.ToString());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid ID");
            }
        }
            
            
    }
}
   
