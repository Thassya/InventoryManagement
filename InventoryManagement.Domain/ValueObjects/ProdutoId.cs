using InventoryManagement.Domain.Common;

namespace InventoryManagement.Domain.ValueObjects
{
    public sealed class ProdutoId : ValueObject
    {
        public Guid Value { get; }

        public ProdutoId(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException("ProdutoId não pode ser nulo.");

            Value = guid;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString() => Value.ToString();
    }
}