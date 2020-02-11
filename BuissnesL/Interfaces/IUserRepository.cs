using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUserList();
        IEnumerable<User> GetUserProfileList(string id);
        User GetUser(int id);
        //void Create(User user);
        //void Update(User user);
        void DeleteUser(int id);
        void SaveUser(User user);
    }
}
