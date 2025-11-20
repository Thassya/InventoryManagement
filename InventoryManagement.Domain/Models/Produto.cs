namespace InventoryManagement.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public Produto()
        {
            
        }

        public Produto(int id, string nome, Categoria categoria)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
        }
    }
}