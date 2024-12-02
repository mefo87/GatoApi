using Data.Gatos;

namespace GatoApi.Gatos;

public class CriarGatoViewModel
{
    public string Nome { get; set; }
    public ECatType Tipo { get; set; }
    public Guid IdDono { get; set; }
    
}