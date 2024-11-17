namespace ScreenSound.Modelos;

internal interface IAvaliacao
{
    void AddNota(Avaliacao a);

    double Media {  get; }
}
