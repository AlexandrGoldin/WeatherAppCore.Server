using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuissnesL;
using PresentationL;
using Hangfire;
using DataL.Entityes;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using PresentationL.Models;
using BuissnesL.Interfaces;
using DataL;
using PresentationL.HangFireWeatherRequestService;

namespace WeatherAppCore.Server.Api.Controllers.WeatherRequest
{
    public class HangFireRequestController : Controller
    {
        private IHangFireWeaserRequest _service;
        public WeatherContext _context;

        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public HangFireRequestController(IHangFireWeaserRequest service, DataManager dataManager, WeatherContext context)
        {
            _service = service;
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);

            _context = context;
        }

        /// HangFire method
        public void Index() 
        {
            _service.GetWeatherResponse();
            // "0 * * * *"- every hour / "*/15 * * * *"- every 15minets
            RecurringJob.AddOrUpdate(() => _service.GetWeatherResponse(), "*/10 * * * *");
        }

    }  
}