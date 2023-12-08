using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalArs_copia.Entities
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("role_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [Required]
        [Column("role_name")]
        public string Name { get; set; }
        
        [Column("role_description")]
        public string Description { get; set; }
    }
    public enum RoleType
    {
        Administrator,
        User
    }
}
