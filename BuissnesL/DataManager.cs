using BuissnesL.Interfaces;
using BuissnesL.Implementations;
using DataL;
using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL
{
   public class DataManager
    {
        private ICityRepository _cityRepository;
        private IJsResponseRepository _jsResponseRepository;
        private IPushMessageRepository _pushMessageRepository;
        private IUserRepository _userRepository;
        private IWeatherRepository _weatherRepository;
        private IWeatherResponseRepository _weatherResponseRepository;
        private IWindRepository _windRepository;

        public DataManager(ICityRepository cityRepository, IJsResponseRepository jsResponseRepository, IPushMessageRepository pushMessageRepository, IUserRepository userRepository, IWeatherRepository weatherRepository, IWeatherResponseRepository weatherResponseRepository,IWindRepository windRepository)
        {
            _cityRepository = cityRepository;
            _jsResponseRepository = jsResponseRepository;
            _pushMessageRepository = pushMessageRepository;
            _userRepository = userRepository;
            _weatherRepository = weatherRepository;
            _weatherResponseRepository = weatherResponseRepository;
            _windRepository = windRepository;
        }

        public ICityRepository City { get { return _cityRepository; } }
        public IJsResponseRepository JsResponse { get { return _jsResponseRepository; } }
        public IPushMessageRepository PushMessage { get { return _pushMessageRepository; } }
        public IUserRepository User { get { return _userRepository; } }
        public IWeatherRepository Weather { get { return _weatherRepository; } }
        public IWeatherResponseRepository WeatherResponse { get { return _weatherResponseRepository; } }
        public IWindRepository Wind { get { return _windRepository; } }
    }
}
