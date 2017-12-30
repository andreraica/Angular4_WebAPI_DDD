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

        public void Delete(string id)
        {
            var searchIndex = _userData.FindIndex(x => x.Id == id);
            if (searchIndex > -1)
                _userData.RemoveAt(searchIndex);
        }
        public void Edit(User entity)
        {
            var searchIndex = _userData.FindIndex(x => x.Id == entity.Id);
            if(searchIndex > -1)
                _userData[searchIndex] = entity;
        }

        public User FindById(string id)
        {
            var searchIndex = _userData.FindIndex(x => x.Id == id);
            return searchIndex > -1 ? _userData[searchIndex] : null;
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
