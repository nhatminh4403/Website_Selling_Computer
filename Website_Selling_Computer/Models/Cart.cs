using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_Selling_Computer.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartID { get; set; }

        [Required]
        public string UserID { get; set; }   

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual User User { get; set; }
    }
}
