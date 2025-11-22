using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.ValueObjects
{
    public sealed class Quantidade : ValueObject
    {
        public decimal Valor { get; }
        public UnidadeMedida Unidade { get; }

        public Quantidade(decimal valor, UnidadeMedida unidadeMedida)
        {
            if (valor <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero para existir.");

            Valor = valor;
            Unidade = unidadeMedida;
        }

        public Quantidade Adicionar(decimal valorASerAdicionado)
        {
            if (Valor <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            return new Quantidade(Valor + valorASerAdicionado, Unidade);
        }

        public Quantidade Remover(decimal valorASerRemovido)
        {
            if (Valor <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");

            if (Valor - valorASerRemovido < 0)
                throw new InvalidOperationException($"Quantidade insuficiente. Quantidade disponível: {Valor}");

            return new Quantidade(Valor - valorASerRemovido, Unidade);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
            yield return Unidade;
        }
    }
}