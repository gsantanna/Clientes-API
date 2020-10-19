using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class ClienteDomainService : BaseDomainService<Cliente>, IClienteDomainService
    {
        public ClienteDomainService(IBaseRepository<Cliente> repository) : base(repository) { }

        public Cliente GetByCpf(string cpf)
        {
            return GetByCpf(cpf);
        }
    }
}
