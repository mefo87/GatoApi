namespace Data.Donos;

public sealed class Dono
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }

    public Dono(string nome, string cpf, string email, string telefone)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
    }

    public void AtualizarDono(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public Dono()
    {
        
    }
}

// Id - Guid
// Nome - string
// Cpf - String