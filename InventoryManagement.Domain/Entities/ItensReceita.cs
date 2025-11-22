using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Models
{
    public class ItensReceita : Entity
    {
        public ProdutoId ProdutoId { get; set; }
        public Quantidade Quantidade { get; set; }
        public string Observacao { get; set; }

        public ItensReceita()
        {

        }

        public ItensReceita(ProdutoId produtoId, Quantidade quantidade, string observacao)
        {
            ProdutoId = produtoId ?? throw new ArgumentNullException(nameof(produtoId));
            Quantidade = quantidade ?? throw new ArgumentNullException(nameof(quantidade));
            Observacao = observacao;
        }

        public void SubstituirQuantidade(decimal novaQuantidade)
        {
            if (novaQuantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            Quantidade = new Quantidade(novaQuantidade, Quantidade.Unidade);
        }
    }
}