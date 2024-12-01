using System.Net;
using Data.Donos;

namespace Business.Donos;

public class DonoResultDto
{
    public HttpStatusCode StatusCode { get; set; }
    public  Dono? Dono { get; set; }

    public DonoResultDto(HttpStatusCode statusCode, Dono? dono)
    {
        StatusCode = statusCode;
        Dono = dono;
    }
}