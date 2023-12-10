using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalArs_copia.Entities
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("account_id")]
        public int Id { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Column("money", TypeName ="REAL")]
        public decimal Money { get; set; }

        [Column("is_blocked")]
        public  bool IsBlocked { get; set; }

        [Column("user_id")]
        [ForeignKey("userId")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
