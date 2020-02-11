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
   public class EFJsResponseRepository : IJsResponseRepository
    {
        private WeatherContext _context;

        public EFJsResponseRepository(WeatherContext context)
        {
            _context = context;
        }

        public IEnumerable<JsResponse> GetJsResponseList()
        {
            return _context.JsResponses.AsNoTracking().ToList();
        }

        //public JsResponse GetJsResponse(int id)
        //{
        //    return _context.JsResponses.Find(id);
        //}

        // 2
        public JsResponse GetJsResponse(int id)
        {
            return _context.JsResponses.Where(i => i.RespIdCity == id).FirstOrDefault();/*Last()*/ 

            //var _jsResponse = _servicesManager.JsResponses.GetJsResponseList()
            //        .Where(i => i.RespIdCity == id).Last();// && i.Id == Max/ == & = ??
        }

        public void DeleteJsResponse(int id)
        {
           JsResponse jsResponse = _context.JsResponses.Find(id);
            _context.JsResponses.Remove(jsResponse);
            _context.SaveChanges();
        }

        public void SaveJsResponse(JsResponse jsResponse)
        {
            if (jsResponse.Id == 0)
                _context.JsResponses.Add(jsResponse);
            else
                _context.Entry(jsResponse).State = EntityState.Modified;
                _context.SaveChanges();
        }
    }
}
