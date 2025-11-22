using InventoryManagement.Domain.Models;

namespace InventoryManagement.Domain.Repositories
{
    public interface IReceitaRepository
    {
        Task<Receita> ObterPorIdAsync(Guid id);
        Task SalvarAsync(Receita receita);
    }
}