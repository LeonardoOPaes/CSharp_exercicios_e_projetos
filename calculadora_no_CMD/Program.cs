namespace calculadora_no_CMD
{
    class Program
    {
        enum Menu { Soma = 1, Subtracao, Divisao, Multiplicacao, Potencia, Raiz, Sair }

        static void Main(string[] args)
        {
            bool naoSair = true;
            while (naoSair)
            {
                Console.WriteLine("Seja bem vindo ao CALC, selecione uma das opções: ");
                Console.WriteLine("1-Soma\n2-Subtração\n3-Divisão\n4-Multiplicação\n5-Potência\n6-Raiz\n7-Sair");

                Menu opcao = (Menu)int.Parse(Console.ReadLine());
             
                
                Console.WriteLine("Você escolheu a opção: " + opcao);

                switch (opcao)
                {
                    case Menu.Soma:
                        Soma();
                        break;
                    case Menu.Subtracao:
                        Subtracao();
                        break;
                    case Menu.Divisao:
                        Divisao();
                        break;
                    case Menu.Multiplicacao:
                        Multiplicacao();
                        break;
                    case Menu.Potencia:
                        Pot();
                        break;
                    case Menu.Raiz:
                        Raiz();
                        break;
                    case Menu.Sair:
                        naoSair = false;
                        break;  
                }
                Console.Clear();

            }
        }

        static void Soma()
        {
            Console.WriteLine("Digite o primeiro número: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            int b = int.Parse(Console.ReadLine());
            int resultado = a + b;
            Console.WriteLine($"O resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar ao menu: ");
        }
        static void Subtracao()
        {
            Console.WriteLine("Digite o primeiro número: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            int b = int.Parse(Console.ReadLine());
            int resultado = a - b;
            Console.WriteLine($"O resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar ao menu: ");
            Console.ReadLine();
        }
        static void Multiplicacao()
        {
            Console.WriteLine("Digite o primeiro número: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            float b = float.Parse(Console.ReadLine());
            float resultado = a * b;
            Console.WriteLine($"O resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar ao menu: ");
            Console.ReadLine();
        }
        static void Divisao()
        {
            bool dividirPorZero = false;
            
            while (dividirPorZero == false)
            {
                Console.WriteLine("Digite o primeiro número: ");
                float a = float.Parse(Console.ReadLine());
                Console.WriteLine("Digite o segundo número: ");
                float b = float.Parse(Console.ReadLine());

                if (b == 0)
                {
                    Console.WriteLine("Não é possível dividir por 0");
                    dividirPorZero = false;
                }
                else
                {
                    float resultado = a / b;
                    Console.WriteLine($"O resultado é: {resultado}");
                    Console.WriteLine("Aperte ENTER para voltar ao menu: ");
                    dividirPorZero = true;
                    Console.ReadLine();
                }
            }

        }
        static void Pot()
        {
            Console.WriteLine("Digite a base: ");
            int baseNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o expoente número: ");
            int expo = int.Parse(Console.ReadLine());
            int resultado = (int)Math.Pow(baseNum, expo);    
            Console.WriteLine($"O resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar ao menu: ");
            Console.ReadLine();
        }
        static void Raiz()
        {
            Console.WriteLine("Digite a base: ");
            int a = int.Parse(Console.ReadLine());
            double resultado = Math.Sqrt(a);
            Console.WriteLine($"O resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar ao menu: ");
            Console.ReadLine();
        }
    }
}