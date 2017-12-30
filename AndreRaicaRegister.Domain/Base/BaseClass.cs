using System;

namespace AndreRaicaRegister.Domain.Base
{
    public class BaseClass
    {
        public BaseClass(string Id)
        {
            _id = string.IsNullOrEmpty(Id) ? Guid.NewGuid().ToString() : Id;
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
