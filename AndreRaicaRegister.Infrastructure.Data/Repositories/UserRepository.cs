using AndreRaicaRegister.Domain.Entities;
using AndreRaicaRegister.Infrastructure.Data.Interface;
using System;
using System.Collections.Generic;

namespace AndreRaicaRegister.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public User Add(User entity)
        {
            return new User();
        }

        public User Delete(User entity)
        {
            return entity;
        }
        public void Edit(User entity)
        {
            var user = entity;
        }

        public User FindById(int id)
        {
            return new User() { Name = "Teste" };
        }

        public IEnumerable<User> GetAll()
        {
            var returnList = new List<User>(); ;
            returnList.Add(new User() { Name = "Teste" });
            return returnList;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
