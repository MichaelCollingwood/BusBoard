﻿using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class Coordinates
    {
        public Result Result { get; set; }
    }

    public class Result
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}