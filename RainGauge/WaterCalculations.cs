using System;
using System.Linq;
namespace RainGauge
{
    public static class WaterCalculations
    {
        public static int DaysSinceWatering()
        {
            Console.Write("Not counting rainfall, how many full days have passed since your garden was watered?: ");
            string input = Console.ReadLine();
            int daysSinceWatering;
            int.TryParse(input, out daysSinceWatering);
            while (daysSinceWatering <= 0)
            {
                Console.WriteLine("You need to enter a positive whole number greater than 0.");
                Console.WriteLine("If you meant to enter 0 then you do not need to water.");
                Console.WriteLine("Try again.");
                Console.Write("How many days have passed without watering?: ");
                input = Console.ReadLine();
                int.TryParse(input, out daysSinceWatering);
            }
            if (daysSinceWatering >= 7)
            {
                daysSinceWatering = 7;
            }
            return daysSinceWatering;
        }

        public static double BaseWaterNeed(int daysSinceWatering)
        {
            double need = (double)daysSinceWatering / 7;
            return need;
        }

        /*Returns increased water demand by factoring an increase of .5 inches for each 10 degrees above 60.
            This formula is for weekly increased demand so it divides by 7 to get the daily increase.*/
        public static double IncreaseWaterDemands(int daysSinceWatering, APIWeatherData weatherData)
        {
            //double increasedDemand = 0;
            double baseTemp = 60;
            double tempFactor = 10;
            double waterFactor = .5;
            double daysPerWeek = 7;

            //for (int i = 1; i <= daysSinceWatering; i++)
            //{
            //    double avgTemp = weatherData.Days[weatherData.Days.Count - i].Temp;
            //    if (avgTemp > baseTemp)
            //    {
            //        increasedDemand += (avgTemp - baseTemp) / tempFactor * waterFactor / daysPerWeek;
            //    }
            //}
            //return increasedDemand;

            return weatherData.Days.Reverse<Day>()
                .Take(daysSinceWatering)
                .Where(d => d.Temperature > baseTemp)
                .Sum(d => ((d.Temperature - baseTemp) / tempFactor * waterFactor / daysPerWeek));
        }

        public static double TotalRainfall(int daysSinceWatering, APIWeatherData weatherData)
        {
            //double totalRainfall = 0;
            //for (int i = 1; i <= daysSinceWatering; i++)
            //{
            //    totalRainfall += weatherData.Days[weatherData.Days.Count - i].Precip;
            //}
            //return totalRainfall;

            return weatherData.Days.Reverse<Day>().Take(daysSinceWatering).Sum(d => d.Precipitation);
        }

        public static void ShouldWater(double baseWaterNeed, double addedWaterDemand, double totalRainfall)
        {
            double waterNeed = baseWaterNeed;
            waterNeed += addedWaterDemand;
            waterNeed -= totalRainfall;
            if (waterNeed >= 1)
            {
                Console.WriteLine("You should water!");
            }
            else
            {
                Console.WriteLine("You do not need to water today.");
            }
        }

        public static double AverageTemp(int daysSinceWatering, APIWeatherData weatherData)
        {
            return weatherData.Days.Reverse<Day>()
                .Take(daysSinceWatering)
                .Average(d => d.Temperature);
        }

        public static double FahrenheitToCelcius(double degreesF)
        {
            double degreesC = (degreesF - 32) * 5 / 9;
            return Math.Round(degreesC, 1);
        }

        public static double InchesToCentimeters(double inches)
        {
            double centimeters = inches * 2.54;
            return Math.Round(centimeters, 1);
        }
    }
}
