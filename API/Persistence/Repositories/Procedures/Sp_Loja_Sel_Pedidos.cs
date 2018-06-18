using API.Core.Repositories;
using API.Models;

namespace API.Persistence.Repositories
{
    public class Sp_Loja_Sel_Pedidos<T> : ProcedureRepository<T>, IProcedureRepository<T> where T:class
    {
        public Sp_Loja_Sel_Pedidos(LojaEntities context)
            : base(context)
        {
        }

        public LojaEntities LojaContext
        {
            get { return Context as LojaEntities; }
        }       
    }
}