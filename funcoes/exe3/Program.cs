
Console.WriteLine("Passe os valores da base: ");
float valorBase = float.Parse(Console.ReadLine());
Console.WriteLine("Passe os valores da altura: ");
float valorAltura = float.Parse(Console.ReadLine());

float resultado = calcularArea(valorBase, valorAltura);

Console.WriteLine("A área do triangulo é: " + resultado + " m2");


static float calcularArea (float basee, float altura)
{
    float area = basee * altura / 2f;
    return area;
}