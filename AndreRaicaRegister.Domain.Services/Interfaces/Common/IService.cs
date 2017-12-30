using AndreRaicaRegister.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreRaicaRegister.Domain.Services.Interfaces.Common
{
    public interface IService<T> where T : IBaseClass
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        //void Save();
    }

}
