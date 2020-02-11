using BuissnesL;
using DataL.Entityes;
using PresentationL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationL.Services
{
   public class CityService
    {
        private BuissnesL.DataManager _dataManager;

        public CityService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public List<CityViewModel> GetCityList()
        {
            var _cityes = _dataManager.City.GetCityList();
            List<CityViewModel> _cityViewModelsList = new List<CityViewModel>();
            foreach (var c in _cityes)
            {
                _cityViewModelsList.Add(CityDbToViewModelById(c.Id));
            }
            return _cityViewModelsList;
        }

        public CityViewModel CityDbToViewModelById(int cityId)
        {
            var _cityDb = _dataManager.City.GetCity(cityId);

            return new CityViewModel() {
                Id = _cityDb.Id,
                Name = _cityDb.Name,
                IdCity = _cityDb.IdCity
            };

        }

        public CityEditModel GetCityEditModel(int cityId)
        {
            if (cityId != 0)
            {
                var _cityDb = _dataManager.City.GetCity(cityId);
                var _cityEditModel = new CityEditModel()
                {
                    Id = _cityDb.Id,
                    Name = _cityDb.Name,
                    IdCity = _cityDb.IdCity                 
                };
                return _cityEditModel;
            }
            else { return new CityEditModel(); }
        }

        public CityViewModel SaveCityEditModelToDb(CityEditModel cityEditModel)
        {
            City _cityDbModel;
            if (cityEditModel.Id != 0)
            {
                _cityDbModel = _dataManager.City.GetCity(cityEditModel.Id);
            }
            else
            {
                _cityDbModel = new City();
            }
            _cityDbModel.Id = cityEditModel.Id;
            _cityDbModel.IdCity = cityEditModel.IdCity;
            _cityDbModel.Name = cityEditModel.Name;
           
            _dataManager.City.SaveCity(_cityDbModel);

            return CityDbToViewModelById(_cityDbModel.Id);
        }

        public CityEditModel CreateNewCityEditModel()
        {
            return new CityEditModel();
        }

        public CityEditModel DeleteCityEditModelToDb(int cityId)
        {
            if (cityId != 0)
            {
                _dataManager.City.DeleteCity(cityId); 
            }
            return new CityEditModel();
        }
    }
}
  