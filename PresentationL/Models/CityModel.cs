using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Models
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }       
    } 
    public class CityEditModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }     
    }
   
}
