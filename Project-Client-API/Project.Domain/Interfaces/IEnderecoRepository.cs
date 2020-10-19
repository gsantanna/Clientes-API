using Project.Domain.Entities;

namespace Project.Domain.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Endereco GetById(long id);
    }
}
