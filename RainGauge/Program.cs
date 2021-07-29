using System;
using static RainGauge.APIWeatherData;
using static RainGauge.WaterCalculations;

namespace RainGauge
{
    class Program
    {
        static void Main(string[] args)
        {
            APIWeatherData weatherData = DeserializeWeather(Query7DayWeatherHistory());

            int daysSinceWatering = DaysSinceWatering();

            double baseWaterNeed = BaseWaterNeed(daysSinceWatering);

            double addedWaterDemand = IncreaseWaterDemands(daysSinceWatering, weatherData);

            double totalRainfall = TotalRainfall(daysSinceWatering, weatherData);

            double avgTemp = AverageTemp(daysSinceWatering, weatherData);

            Console.WriteLine($"In the past {daysSinceWatering} days it has rained {totalRainfall} inches " +
                $"({InchesToCentimeters(totalRainfall)} cm). The average temperature has been " +
                $"{Math.Round(avgTemp, 1)}° F ({FahrenheitToCelcius(avgTemp)}° C) This has created an " +
                $"added water demand of {Math.Round(addedWaterDemand, 1)} inches " +
                $"({InchesToCentimeters(addedWaterDemand)}cm).");

            ShouldWater(baseWaterNeed, addedWaterDemand, totalRainfall);
        }
    }
}
