using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataL.Entityes
{
    public class Weather
    {
        public int Id { get; set; }
        [JsonProperty("id")]
        public int IdWeather { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
