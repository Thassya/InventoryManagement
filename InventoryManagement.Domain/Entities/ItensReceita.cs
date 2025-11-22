using InventoryManagement.Domain.Common;
using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Models
{
    public class ItensReceita : Entity
    {
        public Receita Receita { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        public ItensReceita()
        {
            
        }

        public ItensReceita(Receita receita, Produto produto, decimal quantidade, UnidadeMedida unidadeMedida)
        {
            Receita=receita;
            Produto=produto;
            Quantidade=quantidade;
            UnidadeMedida=unidadeMedida;
        }
    }
}