using System;
namespace RainGauge
{
    public class WeatherRecord
    {
        public string datetime { get; set; }
        public double temp { get; set; }
        public double dew { get; set; }
        public double humidity { get; set; }
        public double precip { get; set; }
        public object precipprob { get; set; }
        public double precipcover { get; set; }
    }
}

//    public class Root
//    {
//        public int queryCost { get; set; }
//        public double latitude { get; set; }
//        public double longitude { get; set; }
//        public string resolvedAddress { get; set; }
//        public string address { get; set; }
//        public string timezone { get; set; }
//        public int tzoffset { get; set; }
//        public List<Day> days { get; set; }
//        public Stations stations { get; set; }
//    }
