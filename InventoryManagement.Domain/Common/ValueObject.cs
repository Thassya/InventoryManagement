namespace InventoryManagement.Domain.Common
{
    public abstract class ValueObject
    {
        /// <summary>
        /// Retorna os componentes que definem a igualdade deste objeto de valor.
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
        }
    }
}