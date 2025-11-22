using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Models
{
    public class EstoqueProduto : Entity
    {
        public ProdutoId ProdutoId { get; set; }
        public Quantidade Quantidade { get; private set; }
        public DateTime? DataValidade { get; private set; }

        public EstoqueProduto() { }

        public EstoqueProduto(ProdutoId produtoId, Quantidade quantidade, DateTime? dataValidade)
        {
            ProdutoId = produtoId ?? throw new ArgumentNullException(nameof(produtoId));
            Quantidade = quantidade ?? throw new ArgumentNullException(nameof(quantidade));
            this.DataValidade = dataValidade;
        }

        public void MudarDataValidade(DateTime novaDataValidade)
        {
            if (DateTime.Compare(DateTime.Now.Date, novaDataValidade.Date) >= 0)
                throw new ArgumentException(nameof(novaDataValidade), "Data de validade precisa ser maior que hoje");

            DataValidade = novaDataValidade;
        }

        public void AumentarQuantidade(decimal novaQuantidade)
        {
            Quantidade = Quantidade.Adicionar(novaQuantidade);
        }

        public void DiminuirQuantidade(decimal novaQuantidade)
        {
            Quantidade = Quantidade.Remover(novaQuantidade);
        }
    }
}