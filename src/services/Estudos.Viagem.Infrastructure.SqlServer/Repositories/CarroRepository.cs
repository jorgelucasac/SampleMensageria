using Estudos.Viagem.Application.Entities;
using Estudos.Viagem.Application.Repositories;

namespace Estudos.Viagem.Infrastructure.SqlServer.Repositories
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(ViagemDataContext context) : base(context)
        {
        }
    }
}