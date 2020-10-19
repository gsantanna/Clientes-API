using Project.Application.Commands.Endereco;
using System;

namespace Project.Application.Interfaces
{
    public interface IEnderecoApplicationService : IDisposable
    {
        void Add(CreateEnderecoCommand command);
        void Update(UpdateEnderecoCommand command);
        void Remove(DeleteEnderecoCommand command);
    }
}
