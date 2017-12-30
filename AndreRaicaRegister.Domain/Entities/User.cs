using AndreRaicaRegister.Domain.Base;
using AndreRaicaRegister.Domain.Interfaces;

namespace AndreRaicaRegister.Domain.Entities
{
    public class User : BaseClass, IUser
    {
        public User() : base()
        {
        }

        public string Name { get; set; }
    }
}
