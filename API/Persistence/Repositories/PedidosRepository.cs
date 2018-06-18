using API.Core.Repositories;
using API.Models;

namespace API.Persistence.Repositories
{
    public class PedidosRepository : Repository<Pedidos>, IPedidosRepository
    {
        public PedidosRepository(LojaEntities context)
            : base(context)
        {
        }

        public LojaEntities LojaContext
        {
            get { return Context as LojaEntities; }
        }
    }
}