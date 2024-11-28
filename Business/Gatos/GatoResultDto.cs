using System.Net;
using Data.Gatos;

namespace Business.Gatos;

public class GatoResultDto
{
    public HttpStatusCode StatusCode { get; set; }
    public Gato? Gato { get; set; }

    public GatoResultDto(HttpStatusCode statusCode, Gato? gato)
    {
        StatusCode = statusCode;
        Gato = gato;
    }
}