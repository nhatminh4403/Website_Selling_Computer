using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IOrderDetails
    {

        Task<OrderDetail> GetOrderDetailsByIdAsync(int id);

    }
}
