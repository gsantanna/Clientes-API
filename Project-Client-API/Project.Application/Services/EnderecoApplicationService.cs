using Project.Application.Commands.Endereco;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.Services
{
    public class EnderecoApplicationService : IEnderecoApplicationService
    {
        private readonly IEnderecoRepository enderecoRepository;

        public EnderecoApplicationService(IEnderecoRepository enderecoRepository)
        {
            this.enderecoRepository = enderecoRepository;
        }

        public void Add(CreateEnderecoCommand command)
        {
            var endereco = new Endereco
            {
                Logradouro = command.Logradouro,
                Bairro = command.Bairro,
                Cidade = command.Cidade,
                Estado = command.Estado,
            };

            var validation = new EnderecoValidation().Validate(endereco);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors.ToString());

            enderecoRepository.Add(endereco);
        }

        public void Update(UpdateEnderecoCommand command)
        {
            var endereco = enderecoRepository.GetById(command.Id);

            if (endereco == null)
                throw new Exception("Endereço não encontrado.");

            endereco.Logradouro = command.Logradouro;
            endereco.Bairro = command.Bairro;
            endereco.Cidade = command.Cidade;
            endereco.Estado = command.Estado;

            var validation = new EnderecoValidation().Validate(endereco);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors.ToString());

            enderecoRepository.Update(endereco);
        }

        public void Remove(DeleteEnderecoCommand command)
        {
            var endereco = enderecoRepository.GetById(command.Id);

            if (endereco == null)
                throw new Exception("Endereço não encontrado.");

            enderecoRepository.Remove(endereco);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return enderecoRepository.GetAll();
        }

        public Endereco GetById(long id)
        {
            return enderecoRepository.GetById(id);
        }

        public void Dispose()
        {
            enderecoRepository.Dispose();
        }
    }
}
