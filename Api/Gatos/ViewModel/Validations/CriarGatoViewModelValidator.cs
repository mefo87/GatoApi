using FluentValidation;

namespace GatoApi.Gatos.Validations;

public class CriarGatoViewModelValidator : AbstractValidator<CriarGatoViewModel>
{
    public CriarGatoViewModelValidator()
    {
        RuleFor(x => x.Tipo)
            .NotEmpty()
            .WithMessage("Tipo de gato é obrigatório!")
            .IsInEnum()
            .WithMessage("Valor informado é inválido!");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome de gato é obrigatório!");
    }
}