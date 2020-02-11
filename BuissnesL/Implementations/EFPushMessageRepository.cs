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
   public class EFPushMessageRepository : IPushMessageRepository
    {
        private WeatherContext _context;

        public EFPushMessageRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<PushMessage> GetPushMessagesList()
        {
            return _context.PushMessages.AsNoTracking().ToList();
        }

        public PushMessage GetPushMessage(int id)
        {
            return _context.PushMessages.Find(id);
        }

        public void DeletePushMessage(int id)
        {
            PushMessage pushMessage = _context.PushMessages.Find(id);
            _context.PushMessages.Remove(pushMessage);
            _context.SaveChanges();
        }

        public void SavePushMessage(PushMessage pushMessage)
        {
            if (pushMessage.Id != 0)
            {
                _context.PushMessages.Update(pushMessage);
            }
            else
            {
                _context.PushMessages.Add(pushMessage);
            }
            _context.SaveChanges();         
        }
    }
}
