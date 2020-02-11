using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL.Interfaces
{
    public interface IWindRepository
    {
        IEnumerable<Wind> GetWindList();
       Wind GetWind(int id);
        //void Create(Wind wind);
        //void Update(Wind item);
        void DeleteWind(int id);
        void SaveWind(Wind wind);
    }
}
