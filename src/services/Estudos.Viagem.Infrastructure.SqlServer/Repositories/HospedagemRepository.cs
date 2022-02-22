using Estudos.Viagem.Application.Entities;
using Estudos.Viagem.Application.Repositories;

namespace Estudos.Viagem.Infrastructure.SqlServer.Repositories
{
    public class HospedagemRepository : Repository<Hospedagem>, IHospedagemRepository
    {
        public HospedagemRepository(ViagemDataContext context) : base(context)
        {
        }
    }
}