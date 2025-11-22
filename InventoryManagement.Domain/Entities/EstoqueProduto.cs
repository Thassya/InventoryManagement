using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Models
{
    public class EstoqueProduto : Entity
    {
        public ProdutoId ProdutoId { get; set; }
        public DateTime? DataValidade { get; private set; }
        public int Quantidade { get; private set; }
        public UnidadeMedida UnidadeMedida { get; private set; }

        public EstoqueProduto() { }

        public EstoqueProduto(ProdutoId produtoId, DateTime? dataValidade, int quantidade, UnidadeMedida unidadeMedida)
        {
            this.ProdutoId = produtoId;
            this.DataValidade = dataValidade;
            this.Quantidade = quantidade;
            this.UnidadeMedida = unidadeMedida;
        }

        public void MudarDataValidade(DateTime novaDataValidade)
        {
            if (DateTime.Compare(DateTime.Now.Date, novaDataValidade.Date) >= 0)
                throw new ArgumentException(nameof(novaDataValidade), "Data de validade precisa ser maior que hoje");

            DataValidade = novaDataValidade;
        }
        public void AumentarQuantidade(int novaQuantidade)
        {
            if (novaQuantidade <= 0)
                throw new ArgumentOutOfRangeException(nameof(novaQuantidade), "Quantidade deve ser maior que 0 para ser adicionada.");

            this.Quantidade += novaQuantidade;
        }
        public void DiminuirQuantidade(int novaQuantidade)
        {
            if (novaQuantidade <= 0)
                throw new ArgumentOutOfRangeException(nameof(novaQuantidade), "Quantidade deve ser maior que 0.");

            if (Quantidade - novaQuantidade < 0)
                throw new InvalidOperationException($"Quantidade maior que o estoque disponível. Estoque: {Quantidade}");

            Quantidade -= novaQuantidade;
        }
        public void MudarUnidadeMedida(UnidadeMedida novaUnidadeMedida)
        {
            UnidadeMedida = novaUnidadeMedida;
        }
    }
}