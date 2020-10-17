using FluentValidation;
using Project.Domain.Entities;
using Project.Domain.Validations.Commons;

namespace Project.Domain.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("Id do cliente obrigatório.");

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("Nome do cliente obrigatório.")
                .Length(1, 30).WithMessage("Nome de ter de 1 a 30 caracteres.");

            RuleFor(a => a.DataNascimento)
                .NotEmpty().WithMessage("Data de Nascimentodo do cliente obrigatória.");

            RuleFor(a => a.Cpf)
                .NotEmpty().WithMessage("CPF do cliente obrigatório.")
                .Length(11).WithMessage("CPF deve ter 11 caracteres.")
                .Must(CpfValidation.IsValid).WithMessage("CPF inválido.");
        }
    }
}
