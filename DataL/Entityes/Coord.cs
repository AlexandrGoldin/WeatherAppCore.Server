using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataL.Entityes
{
    public class Coord
    {
        public int Id { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}
