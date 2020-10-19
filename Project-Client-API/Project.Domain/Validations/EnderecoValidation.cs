using FluentValidation;
using Project.Domain.Entities;

namespace Project.Domain.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(a => a.Logradouro)
                .NotEmpty().WithMessage("Logradouro do cliente obrigatório.")
                .Length(1, 50).WithMessage("Nome de ter de 1 a 50 caracteres.");

            RuleFor(a => a.Bairro)
                .NotEmpty().WithMessage("Bairro do cliente obrigatório.")
                .Length(1, 40).WithMessage("Nome de ter de 1 a 40 caracteres.");

            RuleFor(a => a.Cidade)
                .NotEmpty().WithMessage("Cidade do cliente obrigatório.")
                .Length(1, 40).WithMessage("Nome de ter de 1 a 40 caracteres.");

            RuleFor(a => a.Estado)
                .NotEmpty().WithMessage("Estado do cliente obrigatório.")
                .Length(1, 40).WithMessage("Nome de ter de 1 a 40 caracteres.");
        }
    }
}
