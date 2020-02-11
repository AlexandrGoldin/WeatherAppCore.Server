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
   public class EFWindRepository : IWindRepository
    {
        private WeatherContext _context;

        public EFWindRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<Wind> GetWindList()
        {
            return _context.Winds.AsNoTracking().ToList();
        }

        public Wind GetWind(int id)
        {
            return _context.Winds.Find(id);
        }

        public void DeleteWind(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void SaveWind(Wind wind)
        {
            if (wind.Id == 0) 
                _context.Winds.Add(wind);
            else
                _context.Entry(wind).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
