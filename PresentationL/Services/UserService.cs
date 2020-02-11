using BuissnesL;
using DataL.Entityes;
using PresentationL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationL.Services
{
   public class UserService
    {
        private DataManager _dataManager;

        public UserService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<UserViewModel> GetUserList()       
        {
            var _users = _dataManager.User.GetUserList();
            List<UserViewModel> _userViewModelsList = new List<UserViewModel>();
            foreach (var u in _users)
            {
                _userViewModelsList.Add(UserDbToViewModelById(u.Id));
            }
            return _userViewModelsList;          
        }

        public List<UserViewModel> GetUserProfileList(string id)
        {
            var _users = _dataManager.User.GetUserProfileList(id);
            List<UserViewModel> _userViewModelsList = new List<UserViewModel>();
            foreach (var u in _users)
            {
                _userViewModelsList.Add(UserDbToViewModelById(u.Id));
            }
            return _userViewModelsList;
        }

        public UserViewModel UserDbToViewModelById(int userId)
        {
            var _userDb = _dataManager.User.GetUser(userId);

            return new UserViewModel() {
                Id = _userDb.Id,
                UserIdCity = _userDb.UserIdCity,
                UserKey = _userDb.UserKey,
                UserNameCity = _userDb.UserNameCity,
                DeviceName = _userDb.DeviceName
            };          
        }

        public UserEditModel GetUserEditModel(int userId)
        {
            if (userId != 0)
            {
                var _userDb = _dataManager.User.GetUser(userId);
                var _userEditModel = new UserEditModel() {
                    Id = _userDb.Id,
                    UserIdCity = _userDb.UserIdCity,
                    UserKey = _userDb.UserKey,
                    UserNameCity = _userDb.UserNameCity,
                    DeviceName = _userDb.DeviceName
                };
                return _userEditModel;
            }
            else { return new UserEditModel(); }
        }

        public UserViewModel SaveUserEditModelToDb(UserEditModel userEditModel)
        {
            User _userDbModel;
            if (userEditModel.Id != 0)
            {
                _userDbModel = _dataManager.User.GetUser(userEditModel.Id);
            }
            else
            {
                _userDbModel = new User();
            }          
            _userDbModel.UserIdCity = userEditModel.UserIdCity;
            _userDbModel.UserKey = userEditModel.UserKey;
            _userDbModel.UserNameCity = userEditModel.UserNameCity;
            _userDbModel.DeviceName = userEditModel.DeviceName;
           
            _dataManager.User.SaveUser(_userDbModel);

            return UserDbToViewModelById(_userDbModel.Id);
        }
       
        public UserEditModel CreateNewUserEditModel()
        {
            return new UserEditModel();
        }

        public UserEditModel DeleteUserEditModelToDb(int id)        
        {
            if (id != 0)
            {
                _dataManager.User.DeleteUser(id);               
            }
            return new UserEditModel();
        }    
    }
}
