using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IOrder
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
