using Estudos.Viagem.Application.Entities;
using Estudos.Viagem.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Estudos.Viagem.Infrastructure.SqlServer.Repositories
{
    public class ViagemRepository : Repository<PacoteViagem>, IViagemRepository
    {
        private readonly ViagemDataContext _context;

        public ViagemRepository(ViagemDataContext context) : base(context)
        {
            _context = context;
        }

        public new async Task<IList<PacoteViagem>> GetAll()
        {
            try
            {
                return await _context.Viagens
                    .Include(x => x.Cliente)
                    .Include(x => x.Hospedagem)
                    .Include(x => x.Carro)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao listar as viagens", ex);
            }
        }
    }
}