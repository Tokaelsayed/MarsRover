using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public class RoverSteps
    {
        // Assume max planet length is 100.
        public readonly int MaxPlanetLength = 100;
        public static Boolean Obstacle = false;


        public RoverPosition Forward_On_X(RoverPosition CurrentPosition, List<Obstacles> obstacles)
        {
            int new_X_position;
            RoverPosition roverPosition = new RoverPosition(CurrentPosition.Position_X, CurrentPosition.Position_Y, CurrentPosition.Direction);
            if (roverPosition.Position_X + 1 < MaxPlanetLength) // Inside planet's limits
            { new_X_position = roverPosition.Position_X + 1; }
            else // if Exceed planet lenth Return to Zero.
            { new_X_position = 0; }
            roverPosition.Position_X = new_X_position;

            // Check if the new Position is Obstacles or not.
            if (!(Rover.Stop_Obstacle(roverPosition, obstacles)))
            {
                // if the new Position not an Obstacles return it.
                return roverPosition;
            }
            else
            {
                Obstacle = true;
                // if the new Position is an Obstacles.
                stop_obstacle(CurrentPosition); // Function return old Position and Stop rover
                return CurrentPosition;
            }
        }



        public RoverPosition Forward_On_Y(RoverPosition CurrentPosition,List<Obstacles>obstacles)
        {
            RoverPosition roverPosition = new RoverPosition(CurrentPosition.Position_X, CurrentPosition.Position_Y, CurrentPosition.Direction);
            int new_Y_position;
            if (roverPosition.Position_Y + 1 < MaxPlanetLength)
            {
                new_Y_position = roverPosition.Position_Y + 1;
            }
            else
            { new_Y_position = 0; }
            roverPosition.Position_Y = new_Y_position;
            // Check if the new Position is Obstacles or not.
            if ((Rover.Stop_Obstacle(roverPosition, obstacles)))
            {
                Obstacle = true;
                stop_obstacle(CurrentPosition);
                return CurrentPosition;
            }
            else
            {
                return roverPosition;
            }


        }
        public RoverPosition Backward_On_X(RoverPosition CurrentPosition, List<Obstacles> obstacles)
        {
            RoverPosition roverPosition = new RoverPosition(CurrentPosition.Position_X, CurrentPosition.Position_Y, CurrentPosition.Direction);
            int new_X_position;
            // Negative coordinates are valid.
            new_X_position = (roverPosition.Position_X - 1);
            roverPosition.Position_X = new_X_position;
            // Check if the new Position is Obstacles or not.
            if ((Rover.Stop_Obstacle(roverPosition, obstacles)))
            {
                Obstacle = true;
                stop_obstacle(CurrentPosition);
                return CurrentPosition;
                
            }
            else
            {
                return roverPosition;
            }
        }
        public RoverPosition Backward_On_Y(RoverPosition CurrentPosition, List<Obstacles> obstacles)
        {
            RoverPosition roverPosition = new RoverPosition(CurrentPosition.Position_X, CurrentPosition.Position_Y, CurrentPosition.Direction);
            int new_Y_position;
            // Negative coordinates are valid.
            new_Y_position = (roverPosition.Position_Y - 1 );
            roverPosition.Position_Y = new_Y_position;
            // Check if the new Position is Obstacles or not.
            if (!(Rover.Stop_Obstacle(roverPosition, obstacles)))
            {
                return roverPosition;
            }
            else
            {
                Obstacle = true;
                //stop_obstacle(CurrentPosition);
                return CurrentPosition;
            }
        }
        public string stop_obstacle(RoverPosition position)
        {
            string s = "(" + position.Position_X.ToString() + "," + position.Position_Y.ToString() + "," + position.Direction + "STOPPED";
            return s;
        }
        public string Result(RoverPosition position)
        {
            string res = "";
            res += "Position X: " + position.Position_X;
            res += ",Position Y: " + position.Position_Y;
            res += ",Direction: " + position.Direction;
            return res;

        }

    }
}
