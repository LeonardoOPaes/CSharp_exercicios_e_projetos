using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorEstoque
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco; 
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade de vagas: ");
            int qtdEntrada = int.Parse(Console.ReadLine());
            vagas += qtdEntrada;
            Console.WriteLine("Entrada registrada. Aperte ENTER para sair.");
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto: {nome}");
            Console.WriteLine("Digite a quantidade: ");
            int qtdSaida = int.Parse(Console.ReadLine());
            vagas -= qtdSaida;
            Console.WriteLine("Saída registrada. Aperte ENTER para sair.");
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("==============================");
        }
    }
}
