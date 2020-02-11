using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Models
{
    class WeatherResponseViewModel
    {
        public int Id { get; set; }        
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }        
        public Main Main { get; set; }      
        public double Visibility { get; set; }     
        public Wind Wind { get; set; }       
        public Clouds Clouds { get; set; }      
        public double Dt { get; set; }      
        public Sys Sys { get; set; }     
        public int IdCity { get; set; }      
        public string Name { get; set; }     
        public double Cod { get; set; }
        public string PushMessage { get; set; }
    }

    class WeatherResponseEditModel
    {
        public int Id { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public double Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public double Dt { get; set; }
        public Sys Sys { get; set; }
        public int IdCity { get; set; }
        public string Name { get; set; }
        public double Cod { get; set; }
        public string PushMessage { get; set; }
    }
}

