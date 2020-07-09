using System;
using System.Collections;
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
      
      Console.WriteLine("Give post-code");
      var postcode = Console.ReadLine();
      
      //GetBusTimes(busStopCode);
    }

    static void GetBusTimes(string busStopCode)
    {
      var client = new RestClient("https://api.tfl.gov.uk");
      var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals");
      var response = client.Execute<List<BusPredictions>>(request).Data;

      var NextBuses = response.OrderBy(bus=>bus.TimeToStation).Take(5).ToList();
      foreach (var busTime in NextBuses)
      {
        Console.WriteLine(busTime.ToString());
      }
    }

    static string GetBusStopCode(string postcode)
    {
      var client = new RestClient("https://api.postcodes.io");
      var request = new RestRequest($"postcodes/{postcode}");
      var postCode = client.Execute<PostCode>(request).Data;
      
      /*
      var client = new RestClient("https://api.tfl.gov.uk");
      var request = new RestRequest("StopPoint/?stopTypes=NaptanBusWayPoint&radius=1000&modes=bus&lat={}&lon={}");
      var postCode = client.Execute<PostCode>(request).Data;
      */
    }
  }
}