using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataL.Entityes
{
    public class Sys
    {
        public int Id { get; set; }
        [JsonProperty("type")]
        public double Type { get; set; }
        [JsonProperty("id")]
        public int IdSys { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public double Sunrise { get; set; }
        [JsonProperty("sunset")]
        public double Sunset { get; set; }
    }
}
