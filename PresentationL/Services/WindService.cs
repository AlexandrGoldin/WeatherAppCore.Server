using BuissnesL;
using DataL.Entityes;
using PresentationL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Services
{
   public class WindService
    {       
        private DataManager _dataManager;

        public WindService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<WindViewModel> GetWindList()
        {
            var _winds = _dataManager.Wind.GetWindList();
            List<WindViewModel> _windViewModelsList = new List<WindViewModel>();
            foreach (var w in _winds)
            {
                _windViewModelsList.Add(WindDbToViewModelById(w.Id));
            }
            return _windViewModelsList;
        }

        public WindViewModel WindDbToViewModelById(int windId)
        {
            var _windDb = _dataManager.Wind.GetWind(windId);

            return new WindViewModel()
            {
                Id = _windDb.Id,
                Speed = _windDb.Speed,
                Deg = _windDb.Deg                
            };
        }

        public WindEditModel GetWindEditModel(int windId)
        {
            if (windId != 0)
            {
                var _windDb = _dataManager.Wind.GetWind(windId);
                var _windEditModel = new WindEditModel()
                {
                    Id = _windDb.Id,
                    Speed = _windDb.Speed,
                    Deg = _windDb.Deg
                };
                return _windEditModel;
            }
            else { return new WindEditModel(); }
        }

        public WindViewModel SaveWindViewModellToDb(WindEditModel windEditModel)
        {
            Wind _windDbModel;
            if (windEditModel.Id != 0)
            {
                _windDbModel = _dataManager.Wind.GetWind(windEditModel.Id);
            }
            else
            {
                _windDbModel= new Wind();
            }
            _windDbModel.Speed = windEditModel.Speed;
            _windDbModel.Deg = windEditModel.Deg;
                
            _dataManager.Wind.SaveWind(_windDbModel);

            return WindDbToViewModelById(_windDbModel.Id);
        }

        //public WindEditModel CreateNewWindEditModel()
        //{
        //    return new WindEditModel();
        //}

        public WindEditModel DeleteUserEditModelToDb(int windId)
        {
            if (windId!= 0)
            {
                _dataManager.Wind.DeleteWind(windId);
            }
            return new WindEditModel();
        }
    }
}
