using AndreRaicaRegister.Domain.Entities;
using AndreRaicaRegister.Infrastructure.Data.Interface;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace AndreRaicaRegister.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _userData;

        public UserRepository()
        {
            if (HttpContext.Current.Application["AndreRaicaRegisterData"] == null)
                HttpContext.Current.Application["AndreRaicaRegisterData"] = new List<User>();
            
            _userData = (List<User>)HttpContext.Current.Application["AndreRaicaRegisterData"];
        }

        public User Add(User entity)
        {
            _userData.Add(entity);
            return entity;
        }

        public User Delete(User entity)
        {
            _userData.RemoveAt(_userData.FindIndex(x => x.Id == entity.Id));
            return entity;
        }
        public void Edit(User entity)
        {
            _userData[_userData.FindIndex(x => x.Id == entity.Id)] = entity;
            var user = entity;
        }

        public User FindById(string id)
        {
            return _userData[_userData.FindIndex(x => x.Id == id)];
        }

        public IEnumerable<User> GetAll()
        {
            return _userData;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
