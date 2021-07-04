using System;

namespace RainGauge
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inchesRainfallDaily = { .1, .2, .3, .4, .5, .6 };

            int[] avgTempsDaily = { 80, 75, 60, 90, 88, 73 };

            Console.WriteLine(TotalRainfall(5, inchesRainfallDaily));

            Console.WriteLine(IncreaseWaterDemands(6, avgTempsDaily));

            //DailyWeatherReport[] dailyWeatherReports = {
            //    new DailyWeatherReport(.1, 80),
            //    new DailyWeatherReport(.2, 75),
            //    new DailyWeatherReport(.3, 60),
            //    new DailyWeatherReport(.4, 90),
            //    new DailyWeatherReport(.5, 88),
            //    new DailyWeatherReport(.6, 73)
            //};
        }

        static int DaysSinceWatering()
        {
            Console.WriteLine("Answer the following question without taking rainfal into consideration.");
            Console.Write("How many days have passed without watering?: ");
            string input = Console.ReadLine();
            int daysSinceWatering;
            int.TryParse(input, out daysSinceWatering);
            if (daysSinceWatering > 6)
            {
                daysSinceWatering = 6;
            }
            return daysSinceWatering;
        }

        static double TotalRainfall(int daysSinceWatering, double[] inchesRainfallDaily)
        {
            double totalRainfall = 0;
            for (int i = 1; i <= daysSinceWatering; i++)
            {
                totalRainfall += inchesRainfallDaily[inchesRainfallDaily.Length - i];
            }
            return totalRainfall;
        }

        static double IncreaseWaterDemands(int daysSinceWatering, int[] avgTemps)
        {
            double increasedDemand = 0;
            int avgTemp;
            for (int i = 1; i <= daysSinceWatering; i++)
            {
                avgTemp = avgTemps[avgTemps.Length - i];
                if (avgTemp > 60)
                {
                    increasedDemand += (avgTemp - 60) / 70 * .5;
                }
            }
            return increasedDemand;
        }

        //static bool shouldIWater()
        //{
        //    double waterNeeded = 1;
        //    Console.Write("How many days have passed since you last watered");
        //    string input = Console.ReadLine();
        //    int daysSinceWatering;
        //    int.TryParse(input, out daysSinceWatering);
        //    if (daysSinceWatering > 7)
        //    {
        //        daysSinceWatering = 7;
        //    }
        //    for (int i = 0; i < daysSinceWatering; i++)
        //    {
        //        if 
        //    }

        //        //if avgTemp > 60: value += (avgTemp - 60) / 70 * .5

        //        //value -= total rainfall(7
        //    if (waterNeeded >= 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
