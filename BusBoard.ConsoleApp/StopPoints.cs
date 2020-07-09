using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    }
}