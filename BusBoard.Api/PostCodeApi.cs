using System;
using System.Web.UI.WebControls;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class PostCodeApi
    {
        private static string clientUrl = "https://api.postcodes.io";

        public Coordinates GetCoordinates(string postCode)
        {
            var client = new RestClient(clientUrl);
            var request = new RestRequest($"postcodes/{postCode.Replace(" ", String.Empty)}");
            var coordinates = client.Execute<Coordinates>(request).Data;
            return coordinates;
        }

        public Boolean CheckPostCode(string postCode)
        {
            var client = new RestClient(clientUrl);
            var request = new RestRequest($"postcodes/{postCode}/validate");
            var flag = client.Execute<Check>(request).Data;
            return flag.result == "True";
        }
    }
}