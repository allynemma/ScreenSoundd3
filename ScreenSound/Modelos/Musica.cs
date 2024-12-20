﻿namespace ScreenSound.Modelos;
internal class Musica : IAvaliacao
{
    private List<Avaliacao> notas = new List<Avaliacao>();
    public Musica(Banda artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }

    public string Nome { get; }
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}";

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

    public void AddNota (Avaliacao nota)
    {
        notas.Add(nota);
    }

    public double Media
    {

        get
        {
            if (notas.Count == 0) return 0;
            else { return notas.Average(a => a.Nota); }
        }
    }
}