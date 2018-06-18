using API.Core.Repositories;
using API.Models;

namespace API.Persistence.Repositories
{
    public class ProdutosRepository : Repository<Produtos>, IProdutosRepository
    {
        public ProdutosRepository(LojaEntities context)
            : base(context)
        {
        }

        public LojaEntities LojaContext
        {
            get { return Context as LojaEntities; }
        }
    }
}