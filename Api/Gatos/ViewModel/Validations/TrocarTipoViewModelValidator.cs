using FluentValidation;

namespace GatoApi.Gatos.Validations;

public class TrocarTipoViewModelValidator : AbstractValidator<TrocarTipoViewModel>
{
    public TrocarTipoViewModelValidator()
    {
        RuleFor(x => x.Tipo)
            .NotEmpty()
            .WithMessage("Tipo não pode estar vazio.")
            .IsInEnum()
            .WithMessage("Valor informado é inválido.");
    }
}