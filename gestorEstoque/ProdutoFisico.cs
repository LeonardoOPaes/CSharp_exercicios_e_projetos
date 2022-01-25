using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorEstoque
{
    [System.Serializable]
    internal class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
          this.nome = nome; 
          this.preco = preco;
          this.frete = frete;                     
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade: ");
            int qtdEntrada = int.Parse(Console.ReadLine());
            estoque += qtdEntrada;
            Console.WriteLine("Entrada registrada. Aperte ENTER para sair.");
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade: ");
            int qtdSaida = int.Parse(Console.ReadLine());
            estoque -= qtdSaida;
            Console.WriteLine("Saída registrada. Aperte ENTER para sair.");
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque}");
            Console.WriteLine("==============================");
        }
    }
}
