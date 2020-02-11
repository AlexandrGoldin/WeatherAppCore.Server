using System;
using System.Collections.Generic;
using System.Text;

namespace DataL.Entityes
{
    public class PushMessage
    {
        public int Id { get; set; }      
        public string MesCooling { get; set; }
        public string MesWarming { get; set; }

        public PushMessage(string mesCooling, string mesWarming )
        {
            MesCooling = mesCooling;
            MesWarming = mesWarming;
        }


    }
}
