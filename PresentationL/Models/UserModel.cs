using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserIdCity { get; set; }
        public string UserNameCity { get; set; }
        public string UserKey { get; set; }      
        public string DeviceName { get; set; }        
    }
   
    public class UserEditModel 
    {
        public int Id { get; set; }
        public string UserIdCity { get; set; }
        public string UserNameCity { get; set; }
        public string UserKey { get; set; }        
        public string DeviceName { get; set; }
    }
    
}
