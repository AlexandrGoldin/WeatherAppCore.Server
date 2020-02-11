using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Models
{
   public class PushMessageViewModel
    {
        public int Id { get; set; }
        public string MesCooling { get; set; }
        public string MesWarming { get; set; }

        //public PushMessageViewModel( string message)
        //{
        //    Message = message;
        //}
    }

   public class PushMessageEditModel
    {
        public int Id { get; set; }
        public string MesCooling { get; set; }
        public string MesWarming { get; set; }

        //public PushMessageViewModel(string message)
        //{
        //    Message = message;
        //}
    }
}
