
float recebePizza = pizza(30);

Console.WriteLine("A área da pizza é: " + recebePizza + " cm");

static float pizza(float raio) {
    float pi = 3.14f;
    float area = pi * (raio * raio);
    return area;
}
