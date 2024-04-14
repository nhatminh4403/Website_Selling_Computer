using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Repositories.Interfaces
{
    public interface IPayingMethod
    {
        Task<IEnumerable<PaymentMethod>> GetAllAsync();
        Task<PaymentMethod> GetByIdAsync(int id);
        Task AddAsync(PaymentMethod payment);
        Task UpdateAsync(PaymentMethod payment);
        Task DeleteAsync(int id);
    }
}
