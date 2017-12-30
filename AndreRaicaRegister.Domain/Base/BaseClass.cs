using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreRaicaRegister.Domain.Base
{
    public class BaseClass
    {
        public BaseClass(string Id)
        {
            Id = string.IsNullOrEmpty(Id) ? Guid.NewGuid().ToString() : Id;
        }

        public string Id { get; set; }
    }
}
