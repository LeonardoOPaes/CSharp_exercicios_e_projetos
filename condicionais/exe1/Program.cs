
Console.WriteLine("Escreva um número: ");
int numero1 = int.Parse(Console.ReadLine());
Console.WriteLine("Escreva outro número: ");
int numero2 = int.Parse(Console.ReadLine());
Console.WriteLine("Escreva outro número: ");
int numero3 = int.Parse(Console.ReadLine());

if (numero1 < numero2 && numero1 < numero3)
{
    Console.WriteLine("Número 1 é menor");
}
else if (numero2 < numero1 && numero2 < numero3)
{
    Console.WriteLine("Número 2 é o menor");
}
else if (numero3 < numero1 && numero3 < numero2)
{
    Console.WriteLine("Número 3 é menor");
}
else if (numero1 == numero2 && numero2 == numero3 && numero1 == numero3)
{
    Console.WriteLine("Todos os números são iguais");
} else
{
    Console.WriteLine("A operação falhou, tente novamente!");
}