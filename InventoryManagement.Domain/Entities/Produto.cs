using InventoryManagement.Domain.Common;

namespace InventoryManagement.Domain.Models
{
    public class Produto : Entity
    {       
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public Produto()
        {
            
        }

        public Produto(string nome, Categoria categoria)
        {
            Nome = nome;
            Categoria = categoria;
        }
    }
}