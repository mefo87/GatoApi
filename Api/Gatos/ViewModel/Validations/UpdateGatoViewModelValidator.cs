using FluentValidation;

namespace GatoApi.Gatos.Validations;

public class UpdateGatoViewModelValidator : AbstractValidator<UpdateGatoViewModel>
{
    public UpdateGatoViewModelValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório!")
            .MaximumLength(300);
        
        RuleFor(x => x.Tipo)
            .NotEmpty()
            .WithMessage("Tipo é obrigatório!")
            .IsInEnum()
            .WithMessage("Tipo informado não é válido");
    }
}