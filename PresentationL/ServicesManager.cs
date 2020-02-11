using BuissnesL;
using DataL.Entityes;
using PresentationL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL
{
    public class ServicesManager
    {
        DataManager _dataManager;
        private UserService _userService;
        private CityService _cityService;
        private PushMessageService _pushMessageService;
        private WindService _windService;
        private JsResponseService _jsResponseService;      

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _userService = new UserService(_dataManager);
            _cityService = new CityService(_dataManager);
            _pushMessageService = new PushMessageService(_dataManager);
            _windService = new WindService(_dataManager);
            _jsResponseService = new JsResponseService(_dataManager);            
        }
        public UserService Users { get { return _userService; }  }
        public CityService Cityes { get { return _cityService; } }
        public PushMessageService PushMessages { get { return _pushMessageService; } }
        public WindService Winds { get { return _windService; } }
        public JsResponseService JsResponses { get { return _jsResponseService; } }      
    }
}

