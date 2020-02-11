using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationL;
using PresentationL.Models;

namespace WeatherAppCore.Server.Api.Controllers.UserApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public UserApiController(DataManager dataManager)
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

      // Выводится для Юзера список подписанных им городов для оповещения
      // В представлении на Клиенте в Табл будет Удаление, Добавление
        [HttpGet("{id}")]
        public ActionResult GetUserProfileList(string id)//(int respIdCity) 
        {
            if (id != null)
            {
                var _users = _servicesManager.Users.GetUserProfileList(id);
                return new ObjectResult(_users);
            }
            else return NotFound();
        }

        // Add new User
        // POST api/users
        [HttpPost]
        public ActionResult Post(UserEditModel userEditModel) 
        {
            if (userEditModel == null)
            {
                return BadRequest();
            }
            var _userCurrentModel = (UserEditModel)userEditModel;
            _servicesManager.Users.SaveUserEditModelToDb(_userCurrentModel);
            return Ok(_userCurrentModel);
        }

        //Remuve User
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            UserEditModel _userEditModel;
            if (id != 0)
            {
                _userEditModel = _servicesManager.Users.DeleteUserEditModelToDb(id);

                return RedirectToAction("Index");
            }
            else return NotFound();
        }

        //GET api/users/5
        //[HttpGet("{id}")]
        //public ActionResult Get(int id)//(int respIdCity) 
        //{

        //    if (id != 0)
        //    {
        //        var _user = _servicesManager.Users.GetUserEditModel(id);

        //        return new ObjectResult(_user);
        //    }
        //    else return NotFound();
        //}
    }
}