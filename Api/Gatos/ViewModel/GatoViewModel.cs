using Business.Gatos;
using Data.Gatos;

namespace GatoApi.Gatos;

public class GatoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; } 
    public ECatType Tipo { get; set; }
    public Guid? IdDono { get; set; }
}