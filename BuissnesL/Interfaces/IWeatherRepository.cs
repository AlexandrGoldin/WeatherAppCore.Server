using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL.Interfaces
{
    public interface IWeatherRepository
    {
        IEnumerable<Weather> GetWeatherList();
        Weather GetWeather(int id);
        //void Create(Weather weather);
        //void Update(Weather item);
        void DeleteWeather(int id);
        void SaveWeather(Weather weather);
    }
}
