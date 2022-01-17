Console.WriteLine("Classifique seu nível de urgência entre 1 e 10");
int numero = int.Parse(Console.ReadLine());

if (numero >= 0 && numero <= 3)
{
    Console.WriteLine("BAIXO");
} else if (numero >= 4 && numero <= 6)
{
    Console.WriteLine("MÉDIO");
} else if (numero >= 7 && numero <= 9)
{
    Console.WriteLine("ALTO");
} else
{
    Console.WriteLine("A operação falhou, tente novamente!");
}
