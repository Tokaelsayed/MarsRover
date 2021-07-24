using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public static class Rover
    {

        public static Dictionary<string, RoverPosition> my_Rovers_positions = new Dictionary<string, RoverPosition>();
        public static Dictionary<string, List<Obstacles>> my_Rovers_obstacles = new Dictionary<string, List<Obstacles>>();
        public static Boolean stop = false;
        public static  string AddRover()
        {
            string RoverId= Guid.NewGuid().ToString();
            my_Rovers_positions.Add(RoverId, null);
            my_Rovers_obstacles.Add(RoverId, null);
            return RoverId;
        }
        public static Boolean SetRoverPosition(SetRoverPositionRequest roverPositionRequest)
        {
           if( my_Rovers_positions.ContainsKey(roverPositionRequest.Id))
           {
                my_Rovers_positions[roverPositionRequest.Id]= roverPositionRequest.RoverPosition;
                return true;
           }
            return false;
        }
        public static Boolean AddRoverObstacles(AddObstaclesReuest addObstaclesReuest)
        {
            if (my_Rovers_obstacles.ContainsKey(addObstaclesReuest.Id))
            {
                if (my_Rovers_obstacles[addObstaclesReuest.Id] == null)
                {
                    my_Rovers_obstacles[addObstaclesReuest.Id] = new List<Obstacles>();                  
                }
 
                foreach (var obs in addObstaclesReuest.Obstacles)
                {
                    my_Rovers_obstacles[addObstaclesReuest.Id].Add(obs);
                }
                return true;
            }
            return false;
        }
        public static Boolean CheckCommandRequestID(RunCommandRequest runCommandRequest)
        {
            if (my_Rovers_positions.ContainsKey(runCommandRequest.Id))
                return true;
            return false;
        }

        public static RoverPosition Check_Command_steps(String commands,List<Obstacles> obstacles, RoverPosition position)
        {
            RoverSteps steps = new RoverSteps();
            RoverPosition roverPosition = new RoverPosition(position.Position_X,position.Position_Y,position.Direction);
            foreach (char command in commands)
            {
                if (command == 'F')
                {
                    switch (roverPosition.Direction)
                    {
                        case  "North":
                            {
                                roverPosition = steps.Forward_On_Y(roverPosition, obstacles);
                                break;
                            }
                        case "South":
                            {
                                roverPosition = steps.Backward_On_Y(roverPosition, obstacles);
                                break;
                            }
                        case "East":
                            {
                                roverPosition = steps.Forward_On_X(roverPosition, obstacles);
                                break;

                            }
                        case "West":
                            {
                                roverPosition = steps.Backward_On_X(roverPosition, obstacles);
                                break;
                            }
                            

                    }
                }
                else if (command == 'B')
                {
                    switch (roverPosition.Direction)
                    {
                        case "South":
                            roverPosition = steps.Backward_On_Y(roverPosition, obstacles);
                            break;
                        case "North":
                            roverPosition = steps.Forward_On_Y(roverPosition, obstacles);
                            break;
                        case "West":
                            roverPosition = steps.Backward_On_X(roverPosition, obstacles);
                            break;
                        case "East":
                            roverPosition = steps.Forward_On_X(roverPosition, obstacles);
                            break;
                    }
                }
                else if (command == 'L')
                {
                    roverPosition = RotateLeft(roverPosition);
                }
                else if (command == 'R')
                {
                    roverPosition = RotateRight(roverPosition);
                }
                

            }
            return roverPosition;


        }
        public static RoverPosition RotateLeft(RoverPosition Position)
        {
            RoverPosition roverPosition = new RoverPosition(Position.Position_X, Position.Position_Y, Position.Direction);

            if (roverPosition.Direction == "North") { roverPosition.Direction = "West"; }
            else if (roverPosition.Direction == "South") { roverPosition.Direction = "East"; }
            else if (roverPosition.Direction == "East") { roverPosition.Direction = "North"; }
            else if (roverPosition.Direction == "West") { roverPosition.Direction = "South"; }
            return roverPosition;
        }
        public static RoverPosition RotateRight(RoverPosition Position)
        {
            RoverPosition roverPosition = new RoverPosition(Position.Position_X, Position.Position_Y, Position.Direction);
            if (roverPosition.Direction == "North") { roverPosition.Direction = "East"; }
            else if (roverPosition.Direction == "South") { roverPosition.Direction = "West"; }
            else if (roverPosition.Direction == "East") { roverPosition.Direction = "South"; }
            else if (roverPosition.Direction == "West") { roverPosition.Direction = "North"; }
            return roverPosition;
        }

        public static Boolean Stop_Obstacle(RoverPosition Position, List<Obstacles> obstacles)
        {
            if (obstacles == null)
                return false;
            RoverPosition roverPosition = new RoverPosition(Position.Position_X, Position.Position_Y, Position.Direction);

            foreach (var obstacle in obstacles)
            {
                if (roverPosition.Position_X == obstacle.X && roverPosition.Position_Y == obstacle.Y)
                {
                    stop = true;
                    return true;
                }

            }
            return false;

        }
    }
}