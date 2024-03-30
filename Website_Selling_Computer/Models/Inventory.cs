using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public int ReorderLevel { get; set; }

        [Required]
        public int ManufacturerID { get; set; }

        // Navigation property for related Supplier
        [ForeignKey("ManufacturerID")]
        public virtual Manufacturer Manufacturer { get; set; }

        // Navigation property for related Product
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
