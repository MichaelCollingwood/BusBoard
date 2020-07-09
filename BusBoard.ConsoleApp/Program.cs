using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GeoCoordinatePortable;
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
        
        var postCodeApi = new PostCodeApi();
        var coordinates = postCodeApi.GetCoordinates(postCode);
        
        var tflApi = new TflApi();
        var nearbyStops = tflApi.GetNearbyStops(coordinates);
        foreach (var stop in nearbyStops)
        {
          Console.WriteLine($"Bus Stop Times for: {stop.CommonName}");
          tflApi.GetBusTimes(stop.NaptanId);
        }
      }
    }
  }
}