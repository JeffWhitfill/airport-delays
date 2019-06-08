using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AirportProgram
{
    public class AirportData
    {
        public Airport airport { get; set; }
        public void example()
        {
            var d = new Statistics.NumDelays();
           
        }
    }
    public class Airport
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Statistics statistics { get; set; }
    }
    public class Statistics
    {
        public Flights flights { get; set; }
        public NumDelays numDelays { get; set; }
        public MinutesDelayed minutesDelayed { get; set; }
        public class Flights
        {
            public int cancelled { get; set; }
            //[JsonProperty(PropertyName = "on time")]
            public int onTime { get; set; }
            public int total { get; set; }
            public int delayed { get; set; }
            public int diverted { get; set; }
        }
        public class NumDelays
        {
            //[JsonProperty(PropertyName = "late aircarft")]
            public int lateAircraft { get; set; }
            public int weather { get; set; }
            public int security { get; set; }
            //[JsonProperty(PropertyName = "national aviation system")]
            public int nationalAviationSystem { get; set; }
            public int carrier { get; set; }
        }
        public class MinutesDelayed : NumDelays
        {
            //public int lateAircraft { get; set; }
            //public int weather { get; set; }
            //public int carrier { get; set; }
            //public int security { get; set; }
            public int total { get; set; }
            //public int nationalAviationSystem { get; set; }
        }
    }
    public class Time
    {
        public string label { get; set; }
        public int year { get; set; }
        public int month { get; set; }
    }
    public class Carrier : Airport
    {
        //public string code { get; set; }
        //public string name { get; set; }
    }
}

