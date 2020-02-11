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
    public class EFUserRepository : IUserRepository
    {
        private WeatherContext _context;

        public EFUserRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUserList()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
            
        }

        public IEnumerable<User> GetUserProfileList(string userKey)
        {           
            return _context.Users.Where(i => i.UserKey == userKey).ToList();
        }

        public void SaveUser(User user)
        {
            if (user.Id != 0) _context.Users.Update(user);

            else _context.Users.Add(user);

            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

       
    }
}
