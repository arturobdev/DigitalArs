using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DigitalArs_copia.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        [Column("user_firstName", TypeName = "VARCHAR(100)")]
        public string FirstName { get; set; }

        [Required]
        [Column("user_lastName", TypeName = "VARCHAR(100)")]
        public string LastName { get; set; }

        [Required]
        [Column("user_email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Required]
        [Column("user_password", TypeName = "VARCHAR(100)")]
        public string Password { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [Column("role_id")]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; } = 3;

        public Role? Role { get; set; }
    }
    
}

