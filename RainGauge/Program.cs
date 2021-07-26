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

            Console.WriteLine($"In the past {daysSinceWatering} days it has rained {totalRainfall} inches. " +
                $"Based on temperature you have and increased water demand of {addedWaterDemand} inches.");

            ShouldWater(baseWaterNeed, addedWaterDemand, totalRainfall);
        }
    }
}
