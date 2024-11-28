using Data.Gatos;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Business.Gatos;

public class GatoUpdateDto
{
    public string Nome { get; set; }
    public ECatType Tipo { get; set; }

    public GatoUpdateDto(string nome, ECatType tipo)
    {
        Nome = nome;
        Tipo = tipo;
    }
}   