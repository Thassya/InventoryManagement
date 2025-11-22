using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Entities
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public Categoria Categoria { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        public Produto(string nome, string marca, Categoria categoria, UnidadeMedida unidadeMedida)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode ser vazio.", nameof(nome));

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            Nome = nome.Trim();
            Marca = string.IsNullOrWhiteSpace(marca) ? null : marca.Trim();
            Categoria = categoria;
            UnidadeMedida = unidadeMedida;
        }

        //Conecta esse produto ao objeto de valor e pode ser usado por outros
        public ProdutoId ToProdutoId()
        {
            return new ProdutoId(Id);
        }

        public void RenomearProduto(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("Nome do produto não pode ser vazio.", nameof(novoNome));

            Nome = novoNome.Trim();
        }

        public void AlterarCategoriaDoProduto(Categoria novaCategoria)
        {
            if (novaCategoria == null)
                throw new ArgumentNullException(nameof(novaCategoria));

            Categoria = novaCategoria;
        }

        public void AlterarUnidadeMedidaDoProduto(UnidadeMedida unidade)
        {
            UnidadeMedida = unidade;
        }

        public override string ToString()
        {
            return $"ProdutoId={Id} Nome={Nome} - Marca={Marca} - Categoria={Categoria.Nome} - Medida={UnidadeMedida.ToString()}";
        }
    }
}