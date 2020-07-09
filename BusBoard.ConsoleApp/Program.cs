using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      
      Console.WriteLine("Give bus-stop code");
      var busStopCode = Console.ReadLine();
      
      BusTimes(busStopCode);
    }

    static void BusTimes(string busStopCode)
    {
      var client = new RestClient("https://api.tfl.gov.uk/StopPoint");
      var request = new RestRequest("490008660N/Arrivals?app_id=e359379b&app_key=1c36f466bbec601c4e93d8bbfa43525e");
      var response = client.Execute<List<BusPredictions>>(request).Data;
      
      Console.WriteLine(response.First().DestinationName);
    }
  }
}