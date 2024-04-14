using System.ComponentModel.DataAnnotations;

namespace Website_Selling_Computer.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
