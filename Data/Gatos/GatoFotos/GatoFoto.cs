using System.Text.Json.Serialization;

namespace Data.Gatos.GatoFotos;

public class GatoFoto
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid IdGato { get; private set; }
    
    public string Url { get; private set; }
    
    [JsonIgnore]
    public virtual Gato Gato { get; private set; }

    public GatoFoto(Guid idGato, string url)
    {
        IdGato = idGato;
        Url = url;
    }
    
}

// Id - Guid
// IdGato - Guid
// Url - string