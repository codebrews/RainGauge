using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RainGauge
{
    public class Day
    {
        [JsonPropertyName("datetime")]
        public string DateTime { get; set; }

        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("dew")]
        public double Dew { get; set; }

        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonPropertyName("precip")]
        public double Precip { get; set; }

        [JsonPropertyName("precipprob")]
        public object PrecipProb { get; set; }

        [JsonPropertyName("precipcover")]
        public double PrecipCover { get; set; }
    }

    public class APIWeatherData
    {
        [JsonPropertyName("days")]
        public List<Day> Days { get; set; }

        public static string Query7DayWeatherHistory()
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

        public static APIWeatherData DeserializeWeather(string weatherJson)
        {
            APIWeatherData weatherData = JsonConvert.DeserializeObject<APIWeatherData>(weatherJson);
            return weatherData;
        }
    }
}
