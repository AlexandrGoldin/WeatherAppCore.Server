using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Models
{
   public class JsResponseViewModel
    {
        public int Id { get; set; }

        public string Response { get; set; }
        public int RespIdCity { get; set; }
        public string PushMessage { get; set; }

        //public JsResponseViewModel(/*JsResponseViewModel*/ jsResponseViewModel) :( ?
        //{
        //    Response = jsResponseViewModel;
        //}
    }

   public class JsResponseEditModel
    {
        public int Id { get; set; }

        public string Response { get; set; }
        public int RespIdCity { get; set; }
        public string PushMessage { get; set; }

        //public JsResponse(string response)
        //{
        //    Response = response;
        //}
    }
}
