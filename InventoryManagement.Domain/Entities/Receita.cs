using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.ValueObjects;

namespace InventoryManagement.Domain.Models
{
    public class Receita : Entity
    {
        private readonly List<ItemReceita> _itensDaReceita;
        public string Nome { get; private set; }
        public string Instrucoes { get; private set; }
        public int IdCategoria { get; private set; }
        public int TempoPreparoEmMinutos { get; private set; }
        public Dificuldade Dificuldade { get; private set; }

        public Receita()
        {
            _itensDaReceita = new List<ItemReceita>();
        }

        public Receita(string nome, string instrucoes, int idCategoria, int tempoPreparo, Dificuldade dificuldade)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da receita não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(instrucoes))
                throw new ArgumentException("Instruções/Modo de preparo não pode ser vazio.");

            Nome = nome.Trim();
            Instrucoes = instrucoes;
            IdCategoria = idCategoria;
            TempoPreparoEmMinutos = tempoPreparo;
            Dificuldade = dificuldade;

            _itensDaReceita = new List<ItemReceita>();
        }

        public void AdicionarItemNaReceita(ProdutoId produtoId, decimal quantidade, UnidadeMedida unidadeMedida)
        {
            if (produtoId == null)
                throw new ArgumentNullException(nameof(produtoId));

            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            var itemExistente = _itensDaReceita.FirstOrDefault(f =>
                f.ProdutoId.Equals(produtoId) &&
                f.Quantidade.Unidade == unidadeMedida
            );

            if (itemExistente != null)
            {
                itemExistente.SubstituirQuantidade(quantidade);
                return;
            }

            var novoItemReceita = new ItemReceita(produtoId, new Quantidade(quantidade, unidadeMedida), "");
            _itensDaReceita.Add(novoItemReceita);
        }

        public void RemoverItemDaReceita(ProdutoId produtoId, UnidadeMedida unidadeMedida)
        {
            var itemExistente = _itensDaReceita.FirstOrDefault(f =>
                f.ProdutoId.Equals(produtoId) &&
                f.Quantidade.Unidade == unidadeMedida
            );

            if (itemExistente == null)
                throw new InvalidOperationException("O item não existe na receita.");

            _itensDaReceita.Remove(itemExistente);
        }

        public void RenomearReceita(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("Nome inválido.");

            Nome = novoNome.Trim();
        }

        public void MudarInstrucoesDaReceita(string novasInstrucoes)
        {
            if (string.IsNullOrWhiteSpace(novasInstrucoes))
                throw new ArgumentException("instruções inválidas.");

            Instrucoes = novasInstrucoes.Trim();
        }

        public void AlterarTempoPreparo(int minutos)
        {
            if (minutos <= 0)
                throw new ArgumentException("Tempo de preparo em minutos inválido.");

            TempoPreparoEmMinutos = minutos;
        }

        public void AlterarDificuldadeDaReceita(Dificuldade novaDificuldade)
        {
            Dificuldade = novaDificuldade;
        }
    }
}