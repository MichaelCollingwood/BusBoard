using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class PostCodeApi
    {
        private static string clientUrl = "https://api.postcodes.io";
        public Coordinates GetCoordinates(string postCode)
        {
            var client = new RestClient(clientUrl);
            var request = new RestRequest($"postcodes/{postCode}");
            var coordinates = client.Execute<Coordinates>(request).Data;
            return coordinates;
        }
    }
}