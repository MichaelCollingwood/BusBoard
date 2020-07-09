namespace BusBoard.ConsoleApp
{
    public class BusPredictions
    {
        public string StationName { get; set; }
        public string LineName { get; set; }
        public int TimeToStation { get; set; }
        public string DestinationName { get; set; }
        
        public override string ToString()
        {
            return $"StationName: {StationName}, LineName: {LineName}, TimeToStation: {TimeToStation}, DestinationName: {DestinationName}";
        }
    }
        
}