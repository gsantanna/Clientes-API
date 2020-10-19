using Project.Application.Commands.Endereco;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IEnderecoApplicationService : IDisposable
    {
        void Add(CreateEnderecoCommand command);
        void Update(UpdateEnderecoCommand command);
        void Remove(DeleteEnderecoCommand command);
        IEnumerable<Endereco> GetAll();
        Endereco GetById(long id);
    }
}
