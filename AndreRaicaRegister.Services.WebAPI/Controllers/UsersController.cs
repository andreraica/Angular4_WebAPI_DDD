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
        public string Post([FromBody]User entity)
        {
            return _userManager.Add(entity).Id;
        }

        [HttpPut]
        public void Put([FromBody]User entity)
        {
            _userManager.Edit(entity);
        }

        [HttpDelete]
        public void Delete(string id)
        {
            _userManager.Delete(id);
        }
    }
}
