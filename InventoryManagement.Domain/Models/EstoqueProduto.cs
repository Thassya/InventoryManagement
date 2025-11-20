using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Models
{
    public class EstoqueProduto
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataValidade { get; set; }
        public int Quantidade { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }

        public EstoqueProduto()
        {

        }
        public EstoqueProduto(int id, Usuario usuario, DateTime dataValidade, int quantidade, UnidadeMedida unidadeMedida)
        {
            Id = id;
            Usuario = usuario;
            DataValidade = dataValidade;
            Quantidade = quantidade;
            UnidadeMedida = unidadeMedida;
        }
    }
}