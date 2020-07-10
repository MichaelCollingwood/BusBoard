using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    public class TflApi
    {
        private static string clientUrl = "https://api.tfl.gov.uk";
        RestClient client = new RestClient(clientUrl);
        public List<BusPredictions> GetBusTimes(string busStopCode)
        {
            
            var request = new RestRequest($"StopPoint/{busStopCode}/Arrivals");
            var response = client.Execute<List<BusPredictions>>(request).Data;
            var NextBuses = response.OrderBy(bus=>bus.TimeToStation).Take(5).ToList();
            return NextBuses;
        }
        public List<StopPoint> GetNearbyStops(Coordinates coordinates)
        {
            var request = new RestRequest($"StopPoint/?stopTypes=NaptanPublicBusCoachTram&radius=400&modes=bus" +
                                          $"&lat={coordinates.Result.Latitude}&lon={coordinates.Result.Longitude}");
            var nearbyStops = client.Execute<StopPointResult>(request).Data.StopPoints.OrderBy
                (stops => stops.Distance).ToList();
            
            nearbyStops.RemoveAll(p => GetBusTimes(p.NaptanId).Count == 0);
            return nearbyStops.Take(2).ToList();;
        }
    }
}