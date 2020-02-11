using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL.Interfaces
{
   public interface IWeatherResponseRepository
    {
        IEnumerable<WeatherResponse> GetWeatherResponseList();
        WeatherResponse GetWeatherResponse(int id);
        //void Create(WeatherResponse weatherResponse);
        //void Update(WeatherResponse item);
        void DeleteWeatherResponse(int id);
        void SaveWeatherResponse(WeatherResponse weatherResponse);
    }
}
