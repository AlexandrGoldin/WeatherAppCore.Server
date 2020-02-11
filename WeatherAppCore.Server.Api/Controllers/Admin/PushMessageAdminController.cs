using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesL;
using Microsoft.AspNetCore.Mvc;
using PresentationL;
using PresentationL.Models;

namespace WeatherAppCore.Server.Api.Controllers.Admin
{
    public class PushMessageAdminController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public PushMessageAdminController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager); /*service не зарегистрирован, 
                                                                 исп-ся через (dataManager)*/
        }

        public IActionResult Index()

        {
            var _pushMessageViewModelList = _servicesManager.PushMessages.GetPushMessageList();

            return View(_pushMessageViewModelList);
        }

        [HttpGet]
        public IActionResult PushMessageEditor(int pushMessageId)
        {
            PushMessageEditModel _pushMessageEditModel;
            if (pushMessageId != 0)
            {
                _pushMessageEditModel = _servicesManager.PushMessages.GetPushMessageEditModel(pushMessageId);
                return View(_pushMessageEditModel);
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult PushMessageEditor(PushMessageEditModel pushMessageEditModel)
        {
            var _pushMessageCurrentModel = (PushMessageEditModel) pushMessageEditModel;

            _servicesManager.PushMessages.SavePushMessageEditModelToDb(_pushMessageCurrentModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PushMessageCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PushMessageCreate(PushMessageEditModel pushMessageEditModel)
        {
            var _pushMessageCreatedModel = (PushMessageEditModel) pushMessageEditModel;
            _servicesManager.PushMessages.SavePushMessageEditModelToDb(_pushMessageCreatedModel);
                
            return RedirectToAction("Index");
        }

        public IActionResult PushMessageDelete(int pushMessageId)
        {
            PushMessageEditModel _pushMessageEditModel;
            if (pushMessageId != 0)
            {
                _pushMessageEditModel = _servicesManager.PushMessages.DeletePushMessageEditModelToDb(pushMessageId);

                return RedirectToAction("Index");
            }
            else return NotFound();
        }
    }
}