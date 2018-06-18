using API.Core.Repositories;
using API.Models;

namespace API.Persistence.Repositories
{
    public class ItensPedidosRepository : Repository<ItensPedidos>, IItensPedidosRepository
    {
        public ItensPedidosRepository(LojaEntities context)
            : base(context)
        {
        }

        public LojaEntities LojaContext
        {
            get { return Context as LojaEntities; }
        }
    }
}