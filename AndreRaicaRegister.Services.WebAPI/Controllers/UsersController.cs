using AndreRaicaRegister.Application.Interfaces;
using AndreRaicaRegister.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace AndreRaicaRegister.Services.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userManager.GetAll();
        }

        [HttpGet]
        public User Get(string id)
        {
            return _userManager.FindById(id);
        }

        [HttpPost]
        public void Post([FromBody]User entity)
        {
            _userManager.Add(entity);
        }

        [HttpPut]
        public void Put([FromBody]User entity)
        {
            _userManager.Edit(entity);
        }

        [HttpDelete]
        public void Delete([FromBody]User entity)
        {
            _userManager.Delete(entity);
        }
    }
}
