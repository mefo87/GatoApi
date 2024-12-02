using System.Text.Json.Serialization;
using Data.Donos;
using Data.Gatos.GatoFotos;

namespace Data.Gatos;

public class Gato
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid IdDono { get; private set; }
    public string Nome { get; private set; }
    public ECatType Tipo { get; private set; }
    
    [JsonIgnore]
    public virtual Dono Dono { get; private set; }
    
    public Gato(string nome, ECatType tipo, Guid idDono)
    {
        Nome = nome;
        Tipo = tipo;
        IdDono = idDono;
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