using InventoryManagement.Domain.Enums;

namespace InventoryManagement.Domain.Models
{
    public class Receita
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Instrucoes { get; set; }
        public int IdCategoria { get; set; }
        public int TempoPreparo { get; set; }
        public Dificuldade Dificuldade { get; set; }

        public Receita()
        {

        }

        public Receita(int id, string nome, string instrucoes, int idCategoria, int tempoPreparo, Dificuldade dificuldade)
        {
            Id = id;
            Nome = nome;
            Instrucoes = instrucoes;
            IdCategoria = idCategoria;
            TempoPreparo = tempoPreparo;
            Dificuldade = dificuldade;
        }
    }
}