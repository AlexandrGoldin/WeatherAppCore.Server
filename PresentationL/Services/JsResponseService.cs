using BuissnesL;
using DataL.Entityes;
using PresentationL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Services
{
   public class JsResponseService
    {
        private DataManager _dataManager;

        public JsResponseService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<JsResponseViewModel> GetJsResponseList()
        {
            var _jsResponses = _dataManager.JsResponse.GetJsResponseList();
            List<JsResponseViewModel> _jsResponseViewModelList = new List<JsResponseViewModel>();
            foreach (var j in _jsResponses)
            {
                _jsResponseViewModelList.Add(JsResponseDbToViewModelById(j.Id));
            }
            return _jsResponseViewModelList;
        }

        public JsResponseViewModel JsResponseDbToViewModelById(int jsResponseId)
        {
            var _jsResponsesDb = _dataManager.JsResponse.GetJsResponse(jsResponseId);

            return new JsResponseViewModel()
            {
                Id = _jsResponsesDb.Id,
                Response = _jsResponsesDb.Response,
                RespIdCity = _jsResponsesDb.RespIdCity,
                PushMessage = _jsResponsesDb.PushMessage
            };
        }

        public JsResponseEditModel GetJsResponseEditModel(int jsResponseId)
        {
            if (jsResponseId != 0)
            {
                var _jsResponsesDb = _dataManager.JsResponse.GetJsResponse(jsResponseId);
                var _jsResponseEditModel = new JsResponseEditModel()
                {
                    Id = _jsResponsesDb.Id,
                    Response = _jsResponsesDb.Response,
                    RespIdCity = _jsResponsesDb.RespIdCity,
                    PushMessage = _jsResponsesDb.PushMessage
                };
                return _jsResponseEditModel;
            }
            else { return new JsResponseEditModel(); }
        }

        public JsResponseViewModel SaveJsResponseEditModelToDb(JsResponseEditModel jsResponseEditModel)
        {
            JsResponse _jsResponsesDbModel;
            if (jsResponseEditModel.Id != 0)
            {
                _jsResponsesDbModel = _dataManager.JsResponse.GetJsResponse(jsResponseEditModel.Id);
            }
            else
            {
                //_jsResponsesDbModel = new JsResponse(jsResponseEditModel.Response);
                _jsResponsesDbModel = new JsResponse();
            }
            _jsResponsesDbModel.Response = jsResponseEditModel.Response;
            _jsResponsesDbModel.RespIdCity = jsResponseEditModel.RespIdCity;
            _jsResponsesDbModel.PushMessage = jsResponseEditModel.PushMessage;
            
            _dataManager.JsResponse.SaveJsResponse(_jsResponsesDbModel);

            return JsResponseDbToViewModelById(_jsResponsesDbModel.Id);
        }

        public JsResponseEditModel DeleteJsResponseEditModelToDb(int jsResponseId)
        {
            if (jsResponseId != 0)
            {
                _dataManager.JsResponse.DeleteJsResponse(jsResponseId);
            }
            return new JsResponseEditModel();
        }
    }
}
