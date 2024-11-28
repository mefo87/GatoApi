namespace Data.Gatos;

public sealed class Gato
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nome { get; set; }
    public ECatType Tipo { get; set; }

    public Gato(string nome, ECatType tipo)
    {
        Nome = nome;
        Tipo = tipo;
    }

    public void AtualizarGato(string nome, ECatType tipo)
    {
        Nome = nome;
        Tipo = tipo;
    }

    public void AtualizarTipo(ECatType tipo)
    {
        Tipo = tipo;
    }
}