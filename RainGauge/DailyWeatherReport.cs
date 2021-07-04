using System;
namespace RainGauge
{
    public class DailyWeatherReport
    {
        public double TotalRainfall { get; set; }
        public double HiTemp { get; set; }
        public double LowTemp { get; set; }
        public double AvgTemp { get; set; }


        public DailyWeatherReport(double totalRainfall, double avgTemp)
        {
            TotalRainfall = totalRainfall;
            AvgTemp = avgTemp;
        }
    }
}
