using System.ComponentModel.DataAnnotations;

namespace EjercicioLoginNeitekBackend.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
