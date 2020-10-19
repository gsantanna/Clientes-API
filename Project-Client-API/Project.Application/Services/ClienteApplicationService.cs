using Project.Application.Commands.Cliente;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.Services
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteApplicationService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public void Add(CreateClienteCommand command)
        {
            var cliente = new Cliente
            {
                Nome = command.Nome,
                Cpf = command.Cpf,
                Idade = command.Idade,
                DataNascimento = command.DataNascimento
            };

            var validation = new ClienteValidation().Validate(cliente);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors.ToString());

            clienteRepository.Add(cliente);
        }

        public void Update(UpdadeClienteCommand command)
        {
            var cliente = clienteRepository.GetById(command.Id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            cliente.Nome = command.Nome;
            cliente.Cpf = command.Cpf;
            cliente.Idade = command.Idade;
            cliente.DataNascimento = command.DataNascimento;

            var validation = new ClienteValidation().Validate(cliente);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors.ToString());

            clienteRepository.Update(cliente);
        }

        public void Remove(DeleteClienteCommand command)
        {
            var cliente = clienteRepository.GetById(command.Id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado.");

            clienteRepository.Remove(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clienteRepository.GetAll();
        }

        public Cliente GetById(long id)
        {
            return clienteRepository.GetById(id);
        }
        public void Dispose()
        {
            clienteRepository.Dispose();
        }
    }
}
