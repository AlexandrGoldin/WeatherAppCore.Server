using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesL;
using DataL.Entityes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationL;
using PresentationL.Models;

namespace WeatherAppCore.Server.Api.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherApiController : ControllerBase
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public WeatherApiController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager); /*service не зарегистрирован,              
                                                              исп-ся через (dataManager)*/
        }
        //For List
       [HttpGet]
        public ActionResult Get()
        {
            var _users = _servicesManager.Users.GetUserList();
            return new ObjectResult(_users);
        }

        //GET api/WeatherApi/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)//(int respIdCity) 
        {
            //JsResponse _jsResponse;
            if (id != 0)//(respIdCity != 0)
            {              
                var _jsResponse = _servicesManager.JsResponses.GetJsResponseEditModel(id);
                    
                return new ObjectResult(_jsResponse);
            }
            else return NotFound();
        }
        // Add new Userr
        // POST api/users
        //[HttpPost]
        //public ActionResult Post() 
        //{
           
        //}  
        
        //Remuve User
        // DELETE api/users/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
           
        //}      
    }   
}