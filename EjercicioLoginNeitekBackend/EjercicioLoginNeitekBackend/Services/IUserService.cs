using EjercicioLoginNeitekBackend.DTOs;

namespace EjercicioLoginNeitekBackend.Services
{
    public interface IUserService : ICommonService<UserDTO, UserCreateDTO, UserUpdateDTO>, ILoginService<UserDTO, LoginDTO>
    {
    }
}
