using System;

namespace Project.Application.Commands.Cliente
{
    public class CreateClienteCommand
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
