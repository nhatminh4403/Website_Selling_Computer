using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

        public string ManufacturerImage { get; set; }
    }
}
