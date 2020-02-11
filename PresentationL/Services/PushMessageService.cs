using BuissnesL;
using DataL.Entityes;
using PresentationL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Services
{
   public class PushMessageService
    {
        private DataManager _dataManager;

        public PushMessageService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<PushMessageViewModel> GetPushMessageList()
        {
            var __pushMessages = _dataManager.PushMessage.GetPushMessagesList();
            List<PushMessageViewModel> _pushMessageViewModelList = new List<PushMessageViewModel>();
            foreach (var p in __pushMessages)
            {
                _pushMessageViewModelList.Add(PushMessageDbToViewModelById(p.Id));
            }
            return _pushMessageViewModelList;
        }

        public PushMessageViewModel PushMessageDbToViewModelById(int pushMessageId)
        {   
            var _pushMessageDb = _dataManager.PushMessage.GetPushMessage(pushMessageId);

            return new PushMessageViewModel()
            {
                Id = _pushMessageDb.Id,
                MesCooling = _pushMessageDb.MesCooling,
                MesWarming = _pushMessageDb.MesWarming
            };
        }

        public PushMessageEditModel GetPushMessageEditModel(int pushMessageId)
        {
            if (pushMessageId != 0)
            {
                var _pushMessageDb = _dataManager.PushMessage.GetPushMessage(pushMessageId);
                var _pushMessageEditModel = new PushMessageEditModel()
                {
                    Id = _pushMessageDb.Id,
                    MesCooling = _pushMessageDb.MesCooling,
                    MesWarming = _pushMessageDb.MesWarming
                };
                return _pushMessageEditModel;
            }
            else { return new PushMessageEditModel(); }
        }

        public PushMessageViewModel SavePushMessageEditModelToDb(PushMessageEditModel pushMessageEditModel)
        {
            PushMessage _pushMessageDbModel;
            if (pushMessageEditModel.Id != 0)
            {
                _pushMessageDbModel = _dataManager.PushMessage.GetPushMessage(pushMessageEditModel.Id);
            }
            else
            {
                _pushMessageDbModel = new PushMessage(pushMessageEditModel.MesCooling, pushMessageEditModel.MesWarming);
            }
                _pushMessageDbModel.MesCooling = pushMessageEditModel.MesCooling;
                _pushMessageDbModel.MesWarming = pushMessageEditModel.MesWarming;
            

            _dataManager.PushMessage.SavePushMessage(_pushMessageDbModel);

            return PushMessageDbToViewModelById(_pushMessageDbModel.Id);     
        }

        public PushMessageEditModel DeletePushMessageEditModelToDb(int pushMessageId)
        {
            if (pushMessageId != 0)
            {
                _dataManager.PushMessage.DeletePushMessage(pushMessageId);
            }
            return new PushMessageEditModel();
        }

        public PushMessageEditModel CreateNewPushMessageEditModel()
        {
            return new PushMessageEditModel();
        }


    }
}
