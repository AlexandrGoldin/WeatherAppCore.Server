using BuissnesL;
using BuissnesL.Interfaces;
using DataL;
using DataL.Entityes;
using Newtonsoft.Json;
using PresentationL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PresentationL.HangFireWeatherRequestService
{
    public class HangFireWeatherRequest : IHangFireWeaserRequest
    {
        public WeatherContext _context;

        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public HangFireWeatherRequest(DataManager dataManager, WeatherContext context)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);

            _context = context;
        }

        public void GetWeatherResponse()
        {
            var cities = _dataManager.City.GetCityList();
            foreach (City c in cities)
            {
                string idCity = c.IdCity.ToString();
                int intIdCity = c.IdCity;

                string url = "http://api.openweathermap.org/data/2.5/weather?id=" + idCity + "&units=metric&appid=8cc1a7ea7583dd5d4184ab0858273bc9";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                string response;
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                ////// Save in DB responses in Json and IdCity jn dbo JsResponses!!!
                //JsResponseEditModel jsResponseEditModel = new JsResponseEditModel()
                JsResponse jsResponse = new JsResponse()
                {
                    Response = response,
                    RespIdCity = intIdCity
                };
                _dataManager.JsResponse.SaveJsResponse(jsResponse);
                //_servicesManager.JsResponses.SaveJsResponseEditModelToDb(jsResponseEditModel);

                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                var ListIdWR = _dataManager.WeatherResponse.GetWeatherResponseList().Where(l => l.IdCity == intIdCity)
                .OrderByDescending(l => l.Id).Select(l => l.Id).Take(10).ToList();
                
                var ListIdWind = _servicesManager.Winds.GetWindList().Where(w => ListIdWR.Contains(w.Id))
                 .Select(w => w.Deg).ToList();
                

                //List<User> users = db.Users.ToList();
                /*?*/
                var users = _dataManager.User.GetUserList();

                if (ListIdWind.All(u => u >= 45 & u <= 135))
                {
                    //// Send pushMessage
                    //foreach(var u in users)
                    //{
                    //    if (u.UserIdCity== idCity)
                    //    {
                    //////получить токен прил, токен user и сформир Url
                    //var parameters = new NameValueCollection {
                    //    { "token", "APP_TOKEN" },
                    //    { "user", "USER_KEY" },
                    //    { "message", "hello world" }
                    //};

                    //using (var client = new WebClient())
                    //{
                    //    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                    //}

                    ///// Сохраняю пушСообщение в БД для клиента?              
                    var pushMessageViewModel = _servicesManager.PushMessages.GetPushMessageList().FirstOrDefault();
                    weatherResponse.PushMessage = pushMessageViewModel.MesCooling;
                    jsResponse.PushMessage = pushMessageViewModel.MesCooling;
                }

                if (ListIdWind.All(u => u >= 225 & u <= 315))
                {
                    //// Send pushMessage
                    //foreach(var u in users)
                    //{
                    //    if (u.UserIdCity== idCity)
                    //    {
                    //////получить токен прил, токен user и сформир Url
                    //var parameters = new NameValueCollection {
                    //    { "token", "APP_TOKEN" },
                    //    { "user", "USER_KEY" },
                    //    { "message", "Ожижается повышение температуры воздуха" }
                    //};

                    //using (var client = new WebClient())
                    //{
                    //    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                    //}

                    var pushMessageViewModel = _servicesManager.PushMessages.GetPushMessageList().FirstOrDefault();
                    weatherResponse.PushMessage = pushMessageViewModel.MesWarming;
                    jsResponse.PushMessage = pushMessageViewModel.MesWarming;                         
                }                             
                _dataManager.WeatherResponse.SaveWeatherResponse(weatherResponse);              
            }          
        }
    }
}
