using Estudos.Viagem.Application.Entities;
using Estudos.Viagem.Application.Repositories;

namespace Estudos.Viagem.Infrastructure.SqlServer.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ViagemDataContext context) : base(context)
        {
        }
    }
}