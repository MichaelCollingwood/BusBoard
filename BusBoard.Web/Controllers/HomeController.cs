using System;
using System.Linq;
using System.Web.Mvc;
using BusBoard.ConsoleApp;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {
      // Add some properties to the BusInfo view model with the data you want to render on the page.
      // Write code here to populate the view model with info from the APIs.
      var postCodeApi = new PostCodeApi();
      var coordinates = postCodeApi.GetCoordinates(selection.Postcode);
        
      var tflApi = new TflApi();
      var nearbyStops = tflApi.GetNearbyStops(coordinates);

      var BusStop1TimeTable = nearbyStops[0].TimeTable();
      var BusStop2TimeTable = nearbyStops[1].TimeTable();

      // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
      var info = new BusInfo(selection.Postcode, BusStop1TimeTable, BusStop2TimeTable);
      return View(info);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Information about this site";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Contact us!";

      return View();
    }
  }
}