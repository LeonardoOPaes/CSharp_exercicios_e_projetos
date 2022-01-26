using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;


namespace projetoConsumoAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Cadastra a requisição
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos");
            requisicao.Method = "GET";

            //Executa a requisição
            using (var resposta = requisicao.GetResponse())
            {
                var stream = resposta.GetResponseStream(); // Pega a Stream
                StreamReader leitor = new StreamReader(stream); // Decodifica a Stream
                object dados = leitor.ReadToEnd(); // Passa o resultado aqui

                List<tarefa> tarefas = JsonConvert.DeserializeObject<List<tarefa>>(dados.ToString());

                foreach (var item in tarefas)
                {
                    item.Exibir();
                }

                Console.WriteLine(tarefas);

                stream.Close();
                resposta.Close();
            }

        }
    }
}