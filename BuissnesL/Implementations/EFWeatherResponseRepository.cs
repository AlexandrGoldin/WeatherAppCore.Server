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
   public class EFWeatherResponseRepository : IWeatherResponseRepository
    {
        private WeatherContext _context;

        public EFWeatherResponseRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<WeatherResponse> GetWeatherResponseList()
        {
            return _context.WeatherResponses.AsNoTracking().ToList();
        }

        public WeatherResponse GetWeatherResponse(int id)
        {
            return _context.WeatherResponses.Find(id);
        }

        public void DeleteWeatherResponse(int id)
        {
            WeatherResponse weatherResponse = _context.WeatherResponses.Find(id);
            _context.WeatherResponses.Remove(weatherResponse);
            _context.SaveChanges();
        }

        public void SaveWeatherResponse(WeatherResponse weatherResponse)
        {
            if (weatherResponse.Id == 0)
            {
                _context.WeatherResponses.Add(weatherResponse);
            }
            else
            {
                //_context.Entry(weatherResponse).State = EntityState.Modified;
                _context.WeatherResponses.Update(weatherResponse);

            }
            _context.SaveChanges();
        }
    }
}
