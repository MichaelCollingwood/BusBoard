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

      while (true)
      {
        Console.WriteLine("Give post-code");
        var postCode = Console.ReadLine();
        postCode = "NW51TL";

        var coordinates = GetCoordinates(postCode);
        var nearbyStops = GetNearbyBusStops(coordinates).Take(2).ToList();
        foreach (var stop in nearbyStops)
        {
          Console.WriteLine($"Bus Stop Times for: {stop.CommonName}");
          GetBusTimes(stop.NaptanId);
        }
      }
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

    static List<StopPoint> GetNearbyBusStops(Coordinates coordinates)
    {
      var client = new RestClient("https://api.tfl.gov.uk");
      var request = new RestRequest($"StopPoint/?stopTypes=NaptanPublicBusCoachTram&radius=200&modes=bus" +
                                    $"&lat={coordinates.Result.Latitude}&lon={coordinates.Result.Longitude}");
      var nearbyStops = client.Execute<StopPointResult>(request).Data.StopPoints;

      return nearbyStops;
    }

    private static Coordinates GetCoordinates(string postCode)
    {
      var client = new RestClient("https://api.postcodes.io");
      var request = new RestRequest($"postcodes/{postCode}");
      var coordinates = client.Execute<Coordinates>(request).Data;
      return coordinates;
    }
  }
}