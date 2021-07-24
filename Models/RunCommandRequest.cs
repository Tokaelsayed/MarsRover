using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public class RunCommandRequest
    {
        public string Id;
        public string Command;
        public static RoverPosition position;
        public RunCommandRequest(string Id,string Command)
        {
            this.Id = Id;
            this.Command = Command;
            position= Rover.Check_Command_steps(Command, Rover.my_Rovers_obstacles[Id], Rover.my_Rovers_positions[Id]);
            if (Rover.stop == false)
            { Result(position); }
            else
            {
                Obstacle(Rover.my_Rovers_positions[Id]);
            }
            
        }
        public string Result(RoverPosition position)
        {
            string res = "";
            res += "Position X: "+position.Position_X;
            res += ",Position Y: " + position.Position_Y;
            res += ",Direction: " + position.Direction;
            return res;

        }
        public string Obstacle(RoverPosition position)
        {
            string res = "";
            res += "Position X: " + position.Position_X;
            res += ",Position Y: " + position.Position_Y;
            res += ",Direction: " + position.Direction;
            res += ",STOPPED: ";
            return res;

        }

    }
}