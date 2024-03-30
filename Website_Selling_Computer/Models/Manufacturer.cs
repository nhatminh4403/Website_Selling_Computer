using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class Manufacturer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManufacturerID { get; set; }

        [Required]
        [StringLength(100)]
        public string ManufacturerName { get; set; }

        [StringLength(500)]
        public string ContactInfo { get; set; }

        // Navigation property for related Inventories
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
