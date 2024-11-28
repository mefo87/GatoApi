using Data.Gatos;

namespace Business.Gatos;

public class GatoTypeDto
{
    public ECatType Tipo { get; set; }

    public GatoTypeDto(ECatType tipo)
    {
        Tipo = tipo;
    }
    
}