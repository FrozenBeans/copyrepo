using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IUserInfoRepo
    {
        int Login(string username, string password);
        void Delete(int Id);
        void Add(Domain.UserInfo userinfo);
        void editUserInfo(Domain.UserInfo userinfo);
        Domain.UserInfo getUserInfobyName(string name);
        IEnumerable<Domain.UserInfo> getUsers();
        int getUserId(string username);

        void save();    

    }
}
