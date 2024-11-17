namespace ScreenSound.Modelos;

internal class Avaliacao
{
    public Avaliacao(int nota)
    {
        if (nota >= 0 && nota <=10)
        {
            Nota = nota;

        }
    }

    public int Nota { get; }

    public static Avaliacao Parse (string s)
    {
        int nota = int.Parse(s);
        return new Avaliacao(nota);

    }
}
