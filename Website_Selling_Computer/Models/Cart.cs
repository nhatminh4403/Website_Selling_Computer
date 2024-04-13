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
        public virtual ICollection<Order> Orders { get; set; }
        [NotMapped]
        public List<CartDetail> Items { get; set; } = new List<CartDetail>();
		public void AddItem(CartDetail item)
		{
			var existingItem = Items.FirstOrDefault(i => i.ProductID == item.ProductID);
			if (existingItem != null)
			{
				existingItem.Quantity = existingItem.Quantity + item.Quantity;
			}
			else
			{
				Items.Add(item);
			}
		}
		public void RemoveItem(int productId)
		{
			Items.RemoveAll(i => i.ProductID == productId);
		}
        public void IncreaseQuantity(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductID == productId);
            if (item != null)
            {
                item.Quantity++;
            }
        }
        public void DecreaseQuantity(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductID == productId);
            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
            }
        }
    }
}
