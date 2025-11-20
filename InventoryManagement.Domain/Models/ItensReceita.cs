using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Models
{
    public class ItensReceita
    {
        public int Id { get; set; }
        public Receita Receita { get; set; }
        public Produto Produto { get; set; }
        public decimal Quantidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        public ItensReceita()
        {
            
        }

        public ItensReceita(int id, Receita receita, Produto produto, decimal quantidade, UnidadeMedida unidadeMedida)
        {
            Id=id;
            Receita=receita;
            Produto=produto;
            Quantidade=quantidade;
            UnidadeMedida=unidadeMedida;
        }
    }
}