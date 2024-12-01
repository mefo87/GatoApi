namespace Business.Donos;

public class DonoUpdateDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public DonoUpdateDto(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}