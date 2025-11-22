using InventoryManagement.Domain.Common;

namespace InventoryManagement.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; set; }

        public Categoria()
        {
            
        }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
}