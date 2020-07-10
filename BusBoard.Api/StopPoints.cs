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
        
        // function here to get bus times in a list
        public List<string> TimeTable()
        {
            var timeTable = new List<string>();
            timeTable.Add($"{CommonName}");
            
            var tflApi = new TflApi();
            foreach (var busPrediction in tflApi.GetBusTimes(NaptanId))
            {
                timeTable.Add($"{busPrediction.LineName}: {busPrediction.DestinationName}, {busPrediction.TimeToStation}");
            }
            //Console.WriteLine(string.Join("\n", timeTable));
            
            return timeTable;
        }
    }
}