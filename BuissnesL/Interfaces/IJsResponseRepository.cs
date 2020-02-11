using System;
using System.Collections.Generic;
using System.Text;
using DataL.Entityes;

namespace BuissnesL.Interfaces
{

    public interface IJsResponseRepository
    {
        IEnumerable<JsResponse> GetJsResponseList();
        JsResponse GetJsResponse(int id);
        //void Create(JsResponse item);
        //void Update(JsResponse item);
        void DeleteJsResponse(int id);
        void SaveJsResponse(JsResponse jsResponse);
    }
}
