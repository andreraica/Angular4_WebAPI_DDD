using AndreRaicaRegister.Domain.Entities;
using AndreRaicaRegister.Domain.Services.Interfaces;
using AndreRaicaRegister.Infrastructure.Data.Interface;
using System;
using System.Collections.Generic;

namespace AndreRaicaRegister.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Add(User entity)
        {
            if (this.FindById(entity.Id) != null)
                throw new ApplicationException("User already Exists");

            return _userRepository.Add(entity);
        }

        public void Delete(string id)
        {
            _userRepository.Delete(id);
        }

        public void Edit(User entity)
        {
            _userRepository.Edit(entity);
        }

        public User FindById(string id)
        {
            return _userRepository.FindById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}
