using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class EnderecoDomainService : BaseDomainService<Endereco>, IEnderecoDomainService
    {
        public EnderecoDomainService(IBaseRepository<Endereco> enderecoRepository) : base(enderecoRepository) { }
    }
}
