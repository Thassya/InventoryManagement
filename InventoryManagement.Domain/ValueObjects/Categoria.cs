using InventoryManagement.Domain.Common;

namespace InventoryManagement.Domain.Models
{
    public class Categoria : ValueObject
    {
        public string Nome { get; }

        public Categoria() { }

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