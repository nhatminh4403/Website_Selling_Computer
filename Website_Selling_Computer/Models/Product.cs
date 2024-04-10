using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int CategoryID { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ManufacturerID { get; set; }

        public string? MainImageUrl { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

        // Navigation properties
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }

        public virtual ProductDetail? ProductDetail { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        [ForeignKey("ManufacturerID")]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
