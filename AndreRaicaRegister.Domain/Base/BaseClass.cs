using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreRaicaRegister.Domain.Base
{
    public class BaseClass
    {
        public BaseClass()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
