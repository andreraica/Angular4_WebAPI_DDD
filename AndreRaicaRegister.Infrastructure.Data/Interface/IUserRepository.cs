using AndreRaicaRegister.Domain.Entities;
using AndreRaicaRegister.Infrastructure.Data.Interface.Common;
using System;

namespace AndreRaicaRegister.Infrastructure.Data.Interface
{
    public interface IUserRepository : IRepository<User>, IDisposable
    {
    }
}
