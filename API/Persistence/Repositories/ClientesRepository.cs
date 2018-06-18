using API.Core.Repositories;
using API.Models;

namespace API.Persistence.Repositories
{
    public class ClientesRepository : Repository<Clientes>, IClientesRepository
    {
        public ClientesRepository(LojaEntities context)
            : base(context)
        {
        }

        public LojaEntities LojaContext
        {
            get { return Context as LojaEntities; }
        }
    }
}