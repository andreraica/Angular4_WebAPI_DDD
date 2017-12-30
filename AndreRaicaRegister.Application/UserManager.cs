using AndreRaicaRegister.Application.Interfaces;
using AndreRaicaRegister.Domain.Entities;
using AndreRaicaRegister.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace AndreRaicaRegister.Application
{
    public class UserManager : IUserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public User Add(User entity)
        {
            return _userService.Add(entity);
        }

        public User Delete(User entity)
        {
            return _userService.Delete(entity);
        }

        public void Edit(User entity)
        {
            _userService.Edit(entity);
        }

        public User FindById(int id)
        {
            return _userService.FindById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll();
        }
    }
}
