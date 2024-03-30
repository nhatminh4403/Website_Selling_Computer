using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class ProductDetail
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string CPU { get; set; }

        [Required]
        [StringLength(100)]
        public string RAM { get; set; }

        [Required]
        [StringLength(100)]
        public string Storage { get; set; }

        [Required]
        [StringLength(100)]
        public string Display { get; set; }

        [Required]
        [StringLength(100)]
        public string GraphicsCard { get; set; }

        [Required]
        [StringLength(100)]
        public string OperatingSystem { get; set; }

        [Required]
        [StringLength(100)]
        public string BatteryLife { get; set; }

        [Required]
        [StringLength(100)]
        public string Weight { get; set; }

        [Required]
        [StringLength(100)]
        public string Warranty { get; set; }

        // Navigation property
        public virtual Product Product { get; set; }
    }
}
