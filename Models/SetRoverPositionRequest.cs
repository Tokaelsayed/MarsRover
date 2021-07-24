using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public class SetRoverPositionRequest
    {
        public string Id;
        public RoverPosition RoverPosition;
        public SetRoverPositionRequest(string id,RoverPosition roverposition)
        {
            Id = id;
            RoverPosition = roverposition;
        }

    }
}