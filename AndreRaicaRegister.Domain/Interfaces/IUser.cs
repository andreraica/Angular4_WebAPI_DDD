using AndreRaicaRegister.Domain.Base;

namespace AndreRaicaRegister.Domain.Interfaces
{
    public interface IUser : IBaseClass
    {
        string Name { get; set; }
    }
}
