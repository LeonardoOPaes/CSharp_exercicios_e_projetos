namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            float choco = precoFinal(30);
            float refri = precoFinal(50);
            float bolo = precoFinal(45);
            float sorvete = precoFinal(60);
            float pao = precoFinal(15);

            Console.WriteLine("Preço do Chocolate R$30 + 25% = R$ " + choco);
            Console.WriteLine("Preço do Refrigerante R$50 + 25% = R$ " + refri);
            Console.WriteLine("Preço do Bolo R$45 + 25% = R$ " + bolo);
            Console.WriteLine("Preço do Sorvete R$60 + 25% = R$ " + sorvete);
            Console.WriteLine("Preço do Pao R$15 + 25% = R$ " + pao);
        }
        static float precoFinal(float preco)
        {
            float porcentagem = preco + (preco / 4f);
            return porcentagem;
        }
    }
}



