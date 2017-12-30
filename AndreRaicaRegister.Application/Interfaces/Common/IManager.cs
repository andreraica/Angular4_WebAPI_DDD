using AndreRaicaRegister.Domain.Base;
using System.Collections.Generic;

namespace AndreRaicaRegister.Application.Interfaces.Common
{
    public interface IManager<T> where T : IBaseClass
    {
        IEnumerable<T> GetAll();
        T FindById(string id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        //void Save();
    }
}
