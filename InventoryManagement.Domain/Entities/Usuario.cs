using InventoryManagement.Domain.Common;

namespace InventoryManagement.Domain.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nome, string email, string telefone)
        {           
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}