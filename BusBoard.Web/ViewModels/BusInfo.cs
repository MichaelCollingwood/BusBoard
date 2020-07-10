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
      
      BusStop1 = BusStop1TimeTable[0];
      BusStop1NB1 = BusStop1TimeTable[1];
      BusStop1NB2 = BusStop1TimeTable[2];
      BusStop1NB3 = BusStop1TimeTable[3];
      BusStop1NB4 = BusStop1TimeTable[4];
      BusStop1NB5 = BusStop1TimeTable[5];
      BusStop2 = BusStop2TimeTable[0];
      BusStop2NB1 = BusStop2TimeTable[1];
      BusStop2NB2 = BusStop2TimeTable[2];
      BusStop2NB3 = BusStop2TimeTable[3];
      BusStop2NB4 = BusStop2TimeTable[4];
      BusStop2NB5 = BusStop2TimeTable[5];
    }

    public string PostCode { get; set; }
    public string BusStop1 { get; set; }
    public string BusStop1NB1 { get; set; }
    public string BusStop1NB2 { get; set; }
    public string BusStop1NB3 { get; set; }
    public string BusStop1NB4 { get; set; }
    public string BusStop1NB5 { get; set; }
    
    public string BusStop2 { get; set; }
    public string BusStop2NB1 { get; set; }
    public string BusStop2NB2 { get; set; }
    public string BusStop2NB3 { get; set; }
    public string BusStop2NB4 { get; set; }
    public string BusStop2NB5 { get; set; }
  }
}