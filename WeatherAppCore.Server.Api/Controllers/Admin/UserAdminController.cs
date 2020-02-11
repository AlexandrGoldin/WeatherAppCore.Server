using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesL;
using DataL.Entityes;
using Microsoft.AspNetCore.Mvc;
using PresentationL;
using PresentationL.Models;

namespace WeatherAppCore.Server.Api.Controllers
{
    public class UserAdminController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public UserAdminController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager); /*service не зарегистрирован, 
                                                                 исп-ся через (dataManager)*/
        }
        
        public IActionResult Index()
        
        {
            var _userViewModelList = _servicesManager.Users.GetUserList();
            
            return View(_userViewModelList);
        }

        [HttpGet] 
        public IActionResult UserEditor(int userId) 
        {          
            UserEditModel _userEditModel;
            if (userId != 0)
            {
                _userEditModel = _servicesManager.Users.GetUserEditModel(userId);
                return View(_userEditModel); 
            }
            else  return NotFound();            
        }

        [HttpPost]
        public IActionResult UserEditor(UserEditModel userEditModel) 
        {
            var _userCurrentModel = (UserEditModel) userEditModel;
            
            _servicesManager.Users.SaveUserEditModelToDb(_userCurrentModel);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserCreate(UserEditModel _userEditModel)
        {
            var _userCreatedModel = (UserEditModel)_userEditModel;
            _servicesManager.Users.SaveUserEditModelToDb(_userCreatedModel);
         
           return RedirectToAction("Index");
        }
                      
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
    }
}