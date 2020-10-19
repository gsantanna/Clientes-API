using Project.Domain.Entities;

namespace Project.Domain.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByCpf(string cpf);
        Cliente GetById(long id);
    }
}
