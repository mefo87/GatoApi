using FluentValidation;

namespace GatoApi.Donos.ViewModel.Validations;

public class UpdateDonoViewModelValidator : AbstractValidator<UpdateDonoViewModel>
{
    public UpdateDonoViewModelValidator()
    {
        RuleFor(x => x.Nome)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Nome é obrigatório!")
            .MaximumLength(255)
            .WithMessage("Tamanho máximo para Nome é de 255 caracteres");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Email é obrigatório!")
            .EmailAddress()
            .WithMessage("Email inválido");

        RuleFor(x => x.Telefone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Telefone é obrigatório!")
            .Matches("^\\+?(\\d{1,3})?[-.\\s]?(\\(?\\d{2,3}\\)?)?[-.\\s]?\\d{4,5}[-.\\s]?\\d{4}$")
            .WithMessage("Telefone inválido");
    }
}