using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Models
{
   public class WindViewModel
    {
        public int Id { get; set; }       
        public double Speed { get; set; }       
        public double Deg { get; set; }
    }

   public class WindEditModel
    {
        public int Id { get; set; }
        public double Speed { get; set; }
        public double Deg { get; set; }
    }
}
