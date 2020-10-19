using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Services
{
    public interface IClienteDomainService : IBaseDomainService<Cliente>
    {
        Cliente GetByCpf(string cpf);
    }
}
