using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class AvaliarAlbum : MenuTitulo
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar album");
        Console.Write("Digite o nome da banda com o albúm que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = bandasRegistradas[nomeDaBanda];
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine("Digite o título do album: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (banda.Albuns.Any (a => a.Nome.Equals(nomeDoAlbum)))
            {
                Console.Write($"Qual a nota que a banda {nomeDoAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                Album album = banda.Albuns.First(a => a.Nome == nomeDoAlbum);
                album.AddNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a banda {nomeDoAlbum}");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("O álbum não existe! Favor cadastrá-lo");
                Console.ReadKey();
            }
            
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
