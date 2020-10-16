using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByCpf(string cpf);
    }
}
