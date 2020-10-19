using Project.Application.Commands.Cliente;
using Project.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Project.Application.Interfaces
{
    public interface IClienteApplicationService : IDisposable
    {
        void Add(CreateClienteCommand command);
        void Update(UpdadeClienteCommand command);
        void Remove(DeleteClienteCommand command);
        IEnumerable<Cliente> GetAll();
        Cliente GetById(long id);
    }
}
