using AndreRaicaRegister.Application.Interfaces;
using AndreRaicaRegister.Domain.Entities;
using AndreRaicaRegister.Services.WebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AndreRaicaRegister.Services.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
            _mapper = AutoMapperConfig.Mapper;
        }
        
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var users = _mapper.Map<IEnumerable<UserViewModel>>(_userManager.GetAll());
                return (users != null) ? Request.CreateResponse(HttpStatusCode.OK, users) : Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ApplicationException appEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, appEx.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            try
            {
                var user = _mapper.Map<UserViewModel>(_userManager.FindById(id));
                return (user != null) ? Request.CreateResponse(HttpStatusCode.OK, user) : Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ApplicationException appEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, appEx.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]User entity)
        {
            try
            {
                var user = _mapper.Map<UserViewModel>(_userManager.Add(entity));
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (ApplicationException appEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, appEx.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]User entity)
        {
            try
            {
                _userManager.Edit(entity);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ApplicationException appEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, appEx.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                _userManager.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ApplicationException appEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, appEx.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
