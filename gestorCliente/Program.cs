using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace gestorCliente
{
    class Program
    {
        [System.Serializable]
        struct ModeloCliente
        {
            public string nome;
            public string email;
            public long cpf;
        }

        static List<ModeloCliente> listaClientes = new List<ModeloCliente>();

        enum Menu { Listagem = 1, Adicionar, Remover, Sair }

        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;

            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de clientes - Bem Vindo!");
                Console.WriteLine("1-Listagem\n2-Adicionar\n3-Remover\n4-Sair");
                int intOP = int.Parse(Console.ReadLine());
                Menu opcao = (Menu)intOP;

                switch (opcao)
                {
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Listagem:
                        Listagem();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }
                Console.Clear();
            }

        }

        static void Adicionar()
        {
            ModeloCliente cliente = new ModeloCliente();
            Console.WriteLine("Nome do cliente: ");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("E-mail do cliente: ");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do cliente: ");
            cliente.cpf = long.Parse(Console.ReadLine());

            listaClientes.Add(cliente);
            Salvar();

            Console.WriteLine("Cadastro Finalizado. Aperte ENTER para sair");
            Console.ReadLine();
        }

        static void Listagem()
        {
            if (listaClientes.Count > 0)
            {
                int i = 0;
                foreach (ModeloCliente cliente in listaClientes)
                {
                    Console.WriteLine("===================================");
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"E-mail: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    
                    i++;
                    
                }
            }
            else
            {
                Console.WriteLine("Nenhum Cliente cadastrado.");
            }

            Console.WriteLine("Listagem concluida! Aperte ENTER");
            Console.ReadLine();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, listaClientes);

            stream.Close();
        }

        static void Remover()
        {
            Console.WriteLine("Dados Cadastrados: ");
            Listagem();
            Console.WriteLine("Digite o ID do Cliente que você quer remover: ");
            int pegarID = int.Parse(Console.ReadLine());
            if (pegarID >= 0 && pegarID < listaClientes.Count)
            {

                listaClientes.RemoveAt(pegarID);
                Salvar();

            }
            else
            {
                Console.WriteLine("ID digitado é invalido");
                Console.ReadLine();
            }
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);
            try
            {

                BinaryFormatter encoder = new BinaryFormatter();

                listaClientes = (List<ModeloCliente>)encoder.Deserialize(stream);

                if (listaClientes == null)
                {
                    listaClientes = new List<ModeloCliente>();
                }


            }
            catch (Exception e)
            {
                listaClientes = new List<ModeloCliente>();
            }
            stream.Close();
        }
    }

}