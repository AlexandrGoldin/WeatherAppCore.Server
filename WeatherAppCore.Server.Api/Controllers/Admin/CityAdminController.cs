using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuissnesL;
using PresentationL;
using PresentationL.Models;

namespace WeatherAppCore.Server.Api.Controllers
{
    public class CityAdminController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public CityAdminController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager); /*service не зарегистрирован, 
                                                                   исп-ся через (dataManager)*/
        }

        public IActionResult Index()
        {
            var _cityViewModelList = _servicesManager.Cityes.GetCityList();

            return View(_cityViewModelList);
        }

        [HttpGet]  // не редактирует, а добавляет Юзер ??? :(((
        public IActionResult CityEditor(int cityId) 
        {
            CityEditModel _cityEditModel;
            if (cityId != 0)
            {
                _cityEditModel= _servicesManager.Cityes.GetCityEditModel(cityId);
                return View(_cityEditModel);
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult CityEditor(CityEditModel _cityEditModel) 
        {
            var _cityCurrentModel = (CityEditModel) _cityEditModel;
            _servicesManager.Cityes.SaveCityEditModelToDb(_cityCurrentModel);
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CityCreate()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult CityCreate(CityEditModel _cityEditModel)
        {
            var _cityCreatedModel = (CityEditModel) _cityEditModel;
            _servicesManager.Cityes.SaveCityEditModelToDb(_cityCreatedModel);

            return RedirectToAction("Index");
        }

        public IActionResult CityDelete(int cityId)
        {
            CityEditModel _cityEditModel;
            if (cityId != 0)
            {
                _cityEditModel = _servicesManager.Cityes.DeleteCityEditModelToDb(cityId);

                return RedirectToAction("Index");
            }
            else return NotFound();
        }
    }
}