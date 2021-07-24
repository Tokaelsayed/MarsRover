using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public class AddObstaclesReuest
    {
        public string Id;
        public  List<Obstacles> Obstacles;

        public AddObstaclesReuest(string id, List<Obstacles> obstacles)
        {
            Id = id;
            Obstacles = obstacles;
        }
    }
}