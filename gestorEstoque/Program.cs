using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace gestorEstoque
{
    class Program
    {
        static List<IEstoque> listaProdudos = new List<IEstoque>(); 
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}

        static void Main(string[] args)
        {
            Carregar();

            bool escolheuSair = false;

            while (escolheuSair == false)
            {
                Console.WriteLine("SISTEMA DE ESTOQUE\n");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Entrada\n5-Saida\n6-Sair");

                var opcao = int.Parse(Console.ReadLine());
                Menu escolha = (Menu)opcao;

                if (opcao > 0 && opcao < 7)
                {               
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair |= true;   
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Aperte ENTER para tentar novamente.");
                    Console.ReadLine(); 
                }
                Console.Clear();    
            }
        }

        static void Cadastro()
        {
            
            bool sair = false;
            while (sair == false)
            {

                Console.WriteLine("CADASTRO DE PRODUTOS");
                Console.WriteLine("1-Produto Físico\n2-Ebook\n3-Curso\n4-Sair");
                var opcao = int.Parse(Console.ReadLine());

                if (opcao > 0 && opcao <= 4)
                {
                    switch (opcao)
                    {
                        case 1:
                            CadastrarPFisico();
                            sair = true;
                            Console.WriteLine("Cadastro Realizado! Aperte ENTER para sair!");
                            Console.ReadLine();
                            break;
                        case 2:
                            CadastrarEbook();
                            sair = true;
                            Console.WriteLine("Cadastro Realizado! Aperte ENTER para sair!");
                            Console.ReadLine();
                            break;
                        case 3:
                            CadastrarCurso();
                            sair = true;
                            Console.WriteLine("Cadastro Realizado! Aperte ENTER para sair!");
                            Console.ReadLine();
                            break;
                        case 4:
                            sair = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcão inválida. Aperte ENTER e tente novamente!");
                    Console.ReadLine();
                }
            }
        }
        static void Salvar()
        {
            FileStream salvarProduto = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(salvarProduto, listaProdudos);

            salvarProduto.Close();  
        }
        static void Carregar()
        {
            FileStream salvarProduto = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                listaProdudos = (List<IEstoque>)formatter.Deserialize(salvarProduto);

                if (listaProdudos == null)
                {
                    listaProdudos = new List<IEstoque>();
                }
            }
            catch (Exception e)
            {

                listaProdudos = new List<IEstoque>();
            }

            salvarProduto.Close();
        }
        static void Listagem()
        {
            int i = 0;
            Console.WriteLine("LISTA DE PRODUTOS");
            foreach (IEstoque item in listaProdudos)
            {
                Console.WriteLine("ID: " + i);
                item.Exibir();
                i++;
            }
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Selecione o ID do Produto do qual você quer remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < listaProdudos.Count)
            {
                listaProdudos.RemoveAt(id);
                Salvar();
            }
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Selecione o ID do Produto do qual você quer adicionar uma entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < listaProdudos.Count)
            {
                listaProdudos[id].AdicionarEntrada();
                Salvar();
            }

        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Selecione o ID do Produto do qual você quer adicionar uma baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < listaProdudos.Count)
            {
                listaProdudos[id].AdicionarSaida();
                Salvar();
            }

        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("TELA DE CADASTRO: PRODUTO FÍSICO");
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Preco: ");
            var preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            var frete = float.Parse(Console.ReadLine());  
            
            ProdutoFisico pf =  new ProdutoFisico(nome, preco, frete);  
            
            listaProdudos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("TELA DE CADASTRO: EBOOK");
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Preco: ");
            var preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            var autor = Console.ReadLine();
            
            Ebook eb = new Ebook(nome, preco, autor);
            
            listaProdudos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("TELA DE CADASTRO: CURSO");
            Console.WriteLine("Nome: ");
            var nome = Console.ReadLine();
            Console.WriteLine("Preco: ");
            var preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            var autor = Console.ReadLine();

            Curso cr = new Curso(nome, preco, autor);
            
            listaProdudos.Add(cr);
            Salvar();
        }
    }
}
