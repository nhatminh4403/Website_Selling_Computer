using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class CartDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartDetailID { get; set; }

        [Required]
        public int CartID { get; set; }

        [Required]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryDescription { get; set; } 
        [Required]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Navigation properties
        [ForeignKey("CartID")]
        public virtual Cart Cart { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
