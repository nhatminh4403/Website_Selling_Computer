using Website_Selling_Computer.Models;
namespace Website_Selling_Computer.ViewModel
{
    public class CartViewModel
    {
        public Cart? Cart { get; set; }
        public Order? Order { get; set; }

        public string PaymentMethod { get; set; }
    }
}
