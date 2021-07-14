﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace RainGauge
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializeWeather(Query7DayWeatherHistory());

            //Console.WriteLine(DaysSinceWatering());

            //double[] inchesRainfallDaily = { .1, .2, .3, .4, .5, .6 };

            //int[] avgTempsDaily = { 80, 75, 60, 90, 88, 73 };

            //DaysSinceWatering();

            //Console.WriteLine(TotalRainfall(5, inchesRainfallDaily));

            //Console.WriteLine(IncreaseWaterDemands(6, avgTempsDaily));

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
            if (daysSinceWatering > 6)
            {
                daysSinceWatering = 6;
            }
            return daysSinceWatering;
        }

        static double BaseWaterNeed(int daysSinceWatering)
        {
            double need = (double)daysSinceWatering / 7;
            return need;
        }

        static double IncreaseWaterDemands(int daysSinceWatering, int[] avgTemps)
        {
            double increasedDemand = 0;
            double avgTemp;
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

        static double TotalRainfall(int daysSinceWatering, double[] inchesRainfallDaily)
        {
            double totalRainfall = 0;
            for (int i = 1; i <= daysSinceWatering; i++)
            {
                totalRainfall += inchesRainfallDaily[inchesRainfallDaily.Length - i];
            }
            return totalRainfall;
        }

        static string Query7DayWeatherHistory()
        {
            string apiKey = System.IO.File.ReadAllText("./key.txt");
            string zipCode = "40218";
            string queryUrl = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/" +
                $"services/timeline/{zipCode}/last7days?unitGroup=us&key={apiKey}&include=histfcst";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(queryUrl),
            };
            using var response = client.Send(request);
            response.EnsureSuccessStatusCode();
            string body = response.Content.ReadAsStringAsync().Result;
            return body;
        }

        static void DeserializeWeather(string weatherJson)
        {
            APIWeatherData weatherData = JsonSerializer.Deserialize<APIWeatherData>(weatherJson);

            foreach(var day in weatherData.Days)
            {
                Console.WriteLine($"Date: {day.Date}");
                Console.WriteLine($"AvgTemp: {day.AvgTemp}");
                Console.WriteLine($"Precipitation: {day.Precipitation}");
            }
        }
    }
}
