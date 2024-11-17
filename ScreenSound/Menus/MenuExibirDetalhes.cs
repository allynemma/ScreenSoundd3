using ScreenSound.Modelos;
using ScreenSound.API;
using RestSharp;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhes : MenuTitulo
{
    async Task ExibirResumoAsync (string banda)
    {
        var openAIClient = new OpenAIClient
    ("INSERIR CHAVE DA API");

        string prompt = $"Resuma a banda {banda} em um parágrafo de maneira informal.";

        string resultado = await openAIClient.SendRequest(prompt);
        Console.WriteLine(resultado);
    }

    void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
    public override void Executar(Dictionary<string, Modelos.Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            ExibirResumoAsync(nomeDaBanda);
            Modelos.Banda banda = bandasRegistradas[nomeDaBanda];
            Console.WriteLine($"\nA média da banda {nomeDaBanda} é {banda.Media}.");
            Console.WriteLine("\nDiscografia:");
            foreach (Album album in banda.Albuns)
            {
                Console.WriteLine($"{album.Nome} -> {album.Media}");
            }
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
