using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.ValueObjects;
using InventoryManagement.Domain.Enums;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var categoria = new Categoria("Horifruti");
                var produtoCatalogo = new Produto(
                    nome: "Tomate",
                    marca: "Natural da Terra",
                    categoria: categoria,
                    unidadeMedida: UnidadeMedida.Gramas
                );
                Console.WriteLine("=== Produto Criado: ===");
                Console.WriteLine($"{produtoCatalogo.ToString()}");

                var usuario = new Usuario("Thassya", "thassya@example.com", "123456789");
                var produtoId = produtoCatalogo.ToProdutoId();


                usuario.AdicionarAoEstoque(
                    produtoId: produtoId,
                    quantidade: 3,
                    unidadeMedida: UnidadeMedida.Gramas,
                    validade: DateTime.Today.AddDays(365));

                Console.WriteLine("=== Estoque de produtos do Usuário criado ===");
                foreach (var item in usuario.Estoque)
                {
                    Console.WriteLine(
                       $"ProdutoId={item.ProdutoId}, Qnt={item.Quantidade.Valor} {item.Quantidade.Unidade}, Val={item.DataValidade:d}"
                   );
                }

                var receita = new Receita(
                    nome: "Salada de tomate",
                    instrucoes: "Pique tomate e tempere",
                    dificuldade: Dificuldade.Facil,
                    tempoPreparo: 10,
                    idCategoria: 0 //todo: remover
                );

                receita.AdicionarItemNaReceita(produtoId, quantidade: 2, unidadeMedida: UnidadeMedida.Gramas);

                Console.WriteLine("=== Itens Necessários para Receita ===");
                foreach (var item in receita.Itens)
                {
                    Console.WriteLine(
                        $"ProdutoId={item.ProdutoId}, Qnt={item.Quantidade.Valor} {item.Quantidade.Unidade}"
                    );
                }

                usuario.RemoverDoEstoque(produtoId, quantidade: 2, unidadeMedida: UnidadeMedida.Gramas, validade: DateTime.Today.AddDays(365));

                Console.WriteLine("=== Estoque depois de fazer a receita ===");
                foreach (var item in usuario.Estoque)
                {
                    Console.WriteLine(
                        $"ProdutoId={item.ProdutoId}, Qnt={item.Quantidade.Valor} {item.Quantidade.Unidade}, Val={item.DataValidade:d}"
                    );
                }

                Console.WriteLine("Finalizado sem exceções");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO:");
                Console.WriteLine(ex);
            }

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}