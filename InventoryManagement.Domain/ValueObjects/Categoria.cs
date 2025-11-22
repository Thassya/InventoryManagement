using InventoryManagement.Domain.Common;

namespace InventoryManagement.Domain.ValueObjects
{
    /// <summary>
    /// Objeto de Valor que representa a categoria de um produto (ex: "Hortifruti", "Limpeza").
    /// </summary>
    public class Categoria : ValueObject
    {
        public string Nome { get; }

        public Categoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da categoria não pode ser vazio.", nameof(nome));

            Nome = nome.Trim();
        }

        public override string ToString() => Nome;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome.ToLowerInvariant();
        }
    }
}