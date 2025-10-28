using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioLoginNeitekBackend.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }
    }
}
