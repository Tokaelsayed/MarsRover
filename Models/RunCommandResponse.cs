using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public class RunCommandResponse
    {
        public string Id;
        public RoverPosition roverPosition;
        public RunCommandResponse(RunCommandRequest request,SetRoverPositionRequest positionRequest)
        {
            
           
        }
    }
}