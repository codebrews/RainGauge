using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;

namespace RainGauge
{
    class Program
    {
        static void Main(string[] args)
        {
            string weatherJson = Query7DayWeatherHistory();

            APIWeatherData weatherData = DeserializeWeather(weatherJson);

            int daysSinceWatering = DaysSinceWatering();

            double baseWaterNeed = BaseWaterNeed(daysSinceWatering);

            double addedWaterDemand = IncreaseWaterDemands(daysSinceWatering, weatherData);

            double totalRainfall = TotalRainfall(daysSinceWatering, weatherData);

            Console.WriteLine($"In the past {daysSinceWatering} days it has rained {totalRainfall} inches. " +
                $"Based on temperature you have and increased water demand of {addedWaterDemand} inches");

            ShouldWater(baseWaterNeed, addedWaterDemand, totalRainfall);
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
                daysSinceWatering = 7;
            }
            return daysSinceWatering;
        }

        static double BaseWaterNeed(int daysSinceWatering)
        {
            double need = (double)daysSinceWatering / 7;
            return need;
        }

        static double IncreaseWaterDemands(int daysSinceWatering, APIWeatherData weatherData)
        {
            double increasedDemand = 0;
            double avgTemp;
            for (int i = 1; i <= daysSinceWatering; i++)
            {
                avgTemp = weatherData.Days[weatherData.Days.Count - i].Temp;
                if (avgTemp > 60)
                {
                    increasedDemand += (avgTemp - 60) / 70 * .5;
                }
            }
            return increasedDemand;
        }

        static double TotalRainfall(int daysSinceWatering, APIWeatherData weatherData)
        {
            double totalRainfall = 0;
            for (int i = 1; i <= daysSinceWatering; i++)
            {
                Console.WriteLine(totalRainfall);
                Console.WriteLine(totalRainfall);
                totalRainfall += weatherData.Days[weatherData.Days.Count - i].Precip;
                Console.WriteLine(totalRainfall);
            }
            return totalRainfall;
        }

        static void ShouldWater(double baseWaterNeed, double addedWaterDemand, double totalRainfall)
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

        static string Query7DayWeatherHistory()
        {
            string apiKey = System.IO.File.ReadAllText("./key.txt");
            string zipCode = "40218";
            string queryUrl = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/" +
                $"services/timeline/{zipCode}/last7days?unitGroup=us&key={apiKey}&include=obs";
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

        static APIWeatherData DeserializeWeather(string weatherJson)
        {
            APIWeatherData weatherData = JsonConvert.DeserializeObject<APIWeatherData>(weatherJson);
            return weatherData;
        }
    }
}
