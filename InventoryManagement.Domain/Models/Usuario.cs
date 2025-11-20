namespace InventoryManagement.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string email, string telefone)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id deve ser maior do que zero");

            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}