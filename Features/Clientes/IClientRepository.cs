using Features.Core;

namespace Features.Clientes
{
    public interface IClientRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string Email);
    }
}