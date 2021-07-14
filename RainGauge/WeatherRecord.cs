using System;
using System.Text.Json.Serialization;

namespace RainGauge
{
    public class WeatherRecord
    {
        [JsonPropertyName("datetime")]
        public string Date { get; set; }
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
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
}

//    public class Root
//    {
//        public int queryCost { get; set; }
//        public double latitude { get; set; }
//        public double longitude { get; set; }
//        public string resolvedAddress { get; set; }
//        public string address { get; set; }
//        public string timezone { get; set; }
//        public int tzoffset { get; set; }
//        public List<Day> days { get; set; }
//        public Stations stations { get; set; }
//    }
