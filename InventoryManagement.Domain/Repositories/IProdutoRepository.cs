using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterPorIdAsync(Guid id);
        Task<Produto> ObterPorProdutoIdAsync(ProdutoId produtoId);
        Task<IEnumerable<Produto>> BuscarPorNomeAsync(string termo);
        Task SalvarAsync(Produto produto);
    }
}