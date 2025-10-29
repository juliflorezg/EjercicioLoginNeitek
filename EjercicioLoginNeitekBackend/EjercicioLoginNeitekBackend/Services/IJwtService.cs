namespace EjercicioLoginNeitekBackend.Services
{
    public interface IJwtService
    {
        string GenerateToken(Guid userId, string email, string userType);
    }
}
