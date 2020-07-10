using System;
using System.Linq;
using System.Web.Mvc;
using BusBoard.ConsoleApp;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;

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
      var postCodeApi = new PostCodeApi();
      if (postCodeApi.CheckPostCode(selection.Postcode))
      {
        var coordinates = postCodeApi.GetCoordinates(selection.Postcode);

        var tflApi = new TflApi();
        var nearbyStops = tflApi.GetNearbyStops(coordinates);
        var BusStop1TimeTable = nearbyStops[0].TimeTable();
        var BusStop2TimeTable = nearbyStops[1].TimeTable();

        var info = new BusInfo(selection.Postcode, BusStop1TimeTable, BusStop2TimeTable);
        return View(info);
      }
      else
      {
        ViewBag.Message = "Postcode not recognised";
        return View("ErrorPage");
      }
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