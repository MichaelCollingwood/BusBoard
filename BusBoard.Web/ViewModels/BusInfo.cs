using System;
using System.Collections.Generic;
using System.Linq;
using BusBoard.ConsoleApp;

namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode, List<string> BusStop1TimeTable, List<string> BusStop2TimeTable)
    {
      PostCode = postCode;
      BusStop1 = BusStop1TimeTable;
      BusStop2 = BusStop2TimeTable;
    }

    public string PostCode { get; set; }
    public List<string> BusStop1 { get; set; }
    public List<string> BusStop2 { get; set; }
  }
}