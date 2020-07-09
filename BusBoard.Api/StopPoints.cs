using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    public class StopPointResult
    {
        public List<StopPoint> StopPoints { get; set; }
    }
    public class StopPoint
    {
        public string NaptanId { get; set; }
        public string CommonName { get; set; }
        public string Distance { get; set; }
        
    }
}