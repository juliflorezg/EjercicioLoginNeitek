namespace EjercicioLoginNeitekBackend.DTOs
{
    public class UserUpdateDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
