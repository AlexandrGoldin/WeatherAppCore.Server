using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataL.Entityes
{
    public class Main
    {
        public int Id { get; set; }
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }
}
