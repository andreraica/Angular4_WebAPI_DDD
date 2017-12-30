using AndreRaicaRegister.Domain.Base;
using System.Collections.Generic;

namespace AndreRaicaRegister.Application.Interfaces.Common
{
    public interface IManager<T> where T : IBaseClass
    {
        IEnumerable<T> GetAll();
        T FindById(string id);
        T Add(T entity);
        void Delete(string id);
        void Edit(T entity);
        //void Save();
    }
}
