using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RainGauge
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Day
    {
        [JsonPropertyName("datetime")]
        public string Date { get; set; }
        [JsonPropertyName("temp")]
        public double AvgTemperature { get; set; }
        [JsonPropertyName("dew")]
        public double Dew { get; set; }
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
        [JsonPropertyName("precip")]
        public double Precipitation { get; set; }
        [JsonPropertyName("precipprob")]
        public object PrecipitationProbability { get; set; }
        [JsonPropertyName("precipcover")]
        public double PrecipitationCover { get; set; }
    }

    public class APIWeatherData
    {
        [JsonPropertyName("days")]
        public List<Day> Days { get; set; }
    }
}
