using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageID { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}
