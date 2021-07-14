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

        [JsonPropertyName("datetimeEpoch")]
        public int DatetimeEpoch { get; set; }

        [JsonPropertyName("tempmax")]
        public int Tempmax { get; set; }

        [JsonPropertyName("tempmin")]
        public int Tempmin { get; set; }

        [JsonPropertyName("temp")]
        public object AvgTemp { get; set; }

        [JsonPropertyName("feelslikemax")]
        public int Feelslikemax { get; set; }

        [JsonPropertyName("feelslikemin")]
        public int Feelslikemin { get; set; }

        [JsonPropertyName("feelslike")]
        public object Feelslike { get; set; }

        [JsonPropertyName("dew")]
        public object Dew { get; set; }

        [JsonPropertyName("humidity")]
        public object Humidity { get; set; }

        [JsonPropertyName("precip")]
        public object Precipitation { get; set; }

        [JsonPropertyName("precipprob")]
        public object Precipprob { get; set; }

        [JsonPropertyName("precipcover")]
        public int Precipcover { get; set; }

        [JsonPropertyName("preciptype")]
        public object Preciptype { get; set; }

        [JsonPropertyName("snow")]
        public object Snow { get; set; }

        [JsonPropertyName("snowdepth")]
        public object Snowdepth { get; set; }

        [JsonPropertyName("windgust")]
        public object Windgust { get; set; }

        [JsonPropertyName("windspeed")]
        public object Windspeed { get; set; }

        [JsonPropertyName("winddir")]
        public object Winddir { get; set; }

        [JsonPropertyName("pressure")]
        public object Pressure { get; set; }

        [JsonPropertyName("cloudcover")]
        public object Cloudcover { get; set; }

        [JsonPropertyName("visibility")]
        public object Visibility { get; set; }

        [JsonPropertyName("solarradiation")]
        public object Solarradiation { get; set; }

        [JsonPropertyName("solarenergy")]
        public object Solarenergy { get; set; }

        [JsonPropertyName("uvindex")]
        public object Uvindex { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunriseEpoch")]
        public int SunriseEpoch { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("sunsetEpoch")]
        public int SunsetEpoch { get; set; }

        [JsonPropertyName("moonphase")]
        public double Moonphase { get; set; }

        [JsonPropertyName("conditions")]
        public string Conditions { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("stations")]
        public object Stations { get; set; }
    }

    public class APIWeatherData
    {
        [JsonPropertyName("queryCost")]
        public int QueryCost { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("resolvedAddress")]
        public string ResolvedAddress { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("tzoffset")]
        public double Tzoffset { get; set; }

        [JsonPropertyName("days")]
        public List<Day> Days { get; set; }
    }
}
