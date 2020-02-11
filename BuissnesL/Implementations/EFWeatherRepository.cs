using BuissnesL.Interfaces;
using DataL;
using DataL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesL.Implementations
{
   public class EFWeatherRepository : IWeatherRepository
    {
        private WeatherContext _context;

        public EFWeatherRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<Weather> GetWeatherList()
        {
            return _context.Weathers.AsNoTracking().ToList();
        }

        public Weather GetWeather(int id)
        {
            return _context.Weathers.Find(id);
        }

        public void DeleteWeather(int id)
        {
            Weather weather = _context.Weathers.Find(id);
            _context.Weathers.Remove(weather);
            _context.SaveChanges();
        }

        public void SaveWeather(Weather weather)
        {
            if (weather.Id == 0)
                _context.Weathers.Add(weather);
            else
                _context.Entry(weather).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
