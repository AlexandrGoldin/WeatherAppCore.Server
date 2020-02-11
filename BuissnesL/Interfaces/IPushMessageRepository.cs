using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL.Interfaces
{
   public interface IPushMessageRepository
    {
        IEnumerable<PushMessage> GetPushMessagesList();
        PushMessage GetPushMessage(int id);
        //void Create(PushMessage pushMessage);
        //void Update(PushMessage pushMessage);
        void DeletePushMessage(int id);
        void SavePushMessage(PushMessage pushMessage);
    }
}
