using System;
using System.Collections.Generic;
using System.Linq;

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
        
        public List<List<string>> TimeTable()
        {
            var timeTable = new List<List<string>>();

            var tflApi = new TflApi();
            foreach (var busPrediction in tflApi.GetBusTimes(NaptanId))
            {
                var busListing = new List<string>() { CommonName, busPrediction.LineName, busPrediction.DestinationName, (busPrediction.TimeToStation / 60).ToString() };
                timeTable.Add(busListing);
            }
            return timeTable;
        }
    }
}