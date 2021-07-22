using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    }
}
