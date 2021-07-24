using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_MarsRover.Models
{
    public class RoverPosition
    {
        public int Position_X;
        public int Position_Y;
        public string Direction;
        public RoverPosition(int x,int y,string direction)
        {
            Position_X = x;
            Position_Y = y;
            Direction = direction;
        }
        public override string ToString()
        {
            return "X: " + Position_X + ", Y: " + Position_Y + ", Direction: " + Direction;
        }
    }
}