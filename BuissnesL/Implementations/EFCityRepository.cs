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
    public class EFCityRepository : ICityRepository
    {
        private WeatherContext _context;

        public EFCityRepository(WeatherContext context)
        {
            _context = context;
        }
      
        public void DeleteCity(int id) 
        {
            City city = _context.Cities.Find(id);
            _context.Cities.Remove(city);
            _context.SaveChanges();
        }

        public City GetCity(int id)  
        {
            return _context.Cities.Find(id); 
        }

        public IEnumerable<City> GetCityList() 
        {
            return _context.Cities.AsNoTracking().ToList(); 
        }

        public void SaveCity(City city)
        {
            if (city.Id != 0) _context.Cities.Update(city);

            else _context.Cities.Add(city);

          _context.SaveChanges();
        }

        //public void UpdateCity(City city)
        //{
        //    _context.Entry(city).State = EntityState.Modified;
        //}
    }
}
