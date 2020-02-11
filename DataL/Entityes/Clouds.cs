using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataL.Entityes
{
    public class Clouds
    {
        public int Id { get; set; }
        [JsonProperty("all")]
        public double All { get; set; }
    }
}
