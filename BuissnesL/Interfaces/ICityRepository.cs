using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL.Interfaces
{
   public interface ICityRepository
    {
        IEnumerable<City> GetCityList();
       City GetCity(int id);
        //void CreateCity(City city);
        //void UpdateCity(City city);
        void DeleteCity(int id);
        void SaveCity(City city);
    }
}
