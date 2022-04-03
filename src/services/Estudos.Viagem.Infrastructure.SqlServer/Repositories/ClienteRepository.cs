using Estudos.Viagem.Domain.Entities;
using Estudos.Viagem.Domain.Repositories;

namespace Estudos.Viagem.Infrastructure.SqlServer.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ViagemDataContext context) : base(context)
        {
        }
    }
}