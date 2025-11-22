using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Models
{
    public class Usuario : Entity
    {
        private readonly List<EstoqueProduto> _estoqueProdutos;
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Usuario()
        {
            _estoqueProdutos = new List<EstoqueProduto>();
        }

        public Usuario(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;

            _estoqueProdutos = new List<EstoqueProduto>();
        }

        public void AdicionarAoEstoque(ProdutoId produtoId, decimal quantidade, UnidadeMedida unidadeMedida, DateTime? validade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade precisa ser valida.");

            var produtoExistente = _estoqueProdutos.FirstOrDefault(f =>
                f.ProdutoId.Equals(produtoId) &&
                f.Quantidade.Unidade == unidadeMedida &&
                f.DataValidade == validade);

            if (produtoExistente != null)
            {
                produtoExistente.AumentarQuantidade(quantidade);
                return;
            }

            var novoProduto = new EstoqueProduto(produtoId, new Quantidade(quantidade, unidadeMedida), validade);
            _estoqueProdutos.Add(novoProduto);
        }

        public void RemoverDoEstoque(ProdutoId produtoId, decimal quantidade, UnidadeMedida unidadeMedida, DateTime? validade)
        {
            if (produtoId == null)
                throw new ArgumentNullException(nameof(produtoId));

            var produtoExistente = _estoqueProdutos.FirstOrDefault(f =>
                f.ProdutoId.Equals(produtoId) &&
                f.Quantidade.Unidade == unidadeMedida &&
                f.DataValidade == validade
            );

            if (produtoExistente == null)
                throw new InvalidOperationException("Produto não encontrado no estoque.");

            produtoExistente.DiminuirQuantidade(quantidade);

            if (produtoExistente.Quantidade.Unidade <= 0)
                _estoqueProdutos.Remove(produtoExistente);
        }
    }
}