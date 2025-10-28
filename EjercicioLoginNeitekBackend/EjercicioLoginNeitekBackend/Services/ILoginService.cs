namespace EjercicioLoginNeitekBackend.Services
{
    public interface ILoginService<T, TL>
    {
        T? GetByEmail(TL loginDTO);
        bool ValidatePassword(TL loginDTO);
        Task<string> GetUserTypeNameById(T userDTO);
    }
}
