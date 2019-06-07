using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Data
{
    public class UserInfoRepo : IUserInfoRepo
    {
        private readonly pizzadb_gtContext _db;

        public UserInfoRepo(pizzadb_gtContext db)
        {
            _db = db;
        }
        public int Login(string username, string password)
        {
            if (_db.UserInfo.Where<Models.UserInfo>(x => x.UserName == username && x.Password == password).First() != null)
                return _db.UserInfo.Where<Models.UserInfo>(x => x.UserName == username).First<Models.UserInfo>().UserId;
            else return 0;
        }

        public void Delete(int Id)
        {
            _db.UserInfo.Remove(_db.UserInfo.Find(Id));
        }
        public void Add(Domain.UserInfo userinfo)
        {
            _db.UserInfo.Add(Mapper.Map(userinfo));
        }

        public void editUserInfo(Domain.UserInfo userinfo)
        {
            if (_db.UserInfo.Find(userinfo.userId) != null)
                _db.UserInfo.Update(Mapper.Map(userinfo));
        }
        public Domain.UserInfo getUserInfobyName(string name)
        {
            var element = _db.UserInfo.Where(x => x.FirstName.Contains(name)|| x.LastName.Contains(name)).FirstOrDefault();
            if (element != null)
                return Mapper.Map(element);
            else
                return null;
        }
        public IEnumerable<Domain.UserInfo> getUsers()
        {
            //var x = _db.UserInfo;
            return _db.UserInfo.Select(x => Mapper.Map(x));
        }
        public int getUserId(string username)
        {
            if (_db.UserInfo.Where(x => x.UserName == username).FirstOrDefault() != null)
                return Mapper.Map(_db.UserInfo.Where(x => x.UserName == username).FirstOrDefault()).userId;
            else
                return 0;
        }


        public void save()
        {
            _db.SaveChanges();
        }
    }
}
