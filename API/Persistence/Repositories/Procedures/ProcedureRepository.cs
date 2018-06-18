using API.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace API.Persistence.Repositories
{
    public class ProcedureRepository<T> : IProcedureRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public ProcedureRepository(DbContext context)
        {
            Context = context;
        }
        
        public IEnumerable<T> Proc_Retorno(string procedure, SqlParameter[] parametros)
        {
            return Context.Database.SqlQuery<T>(procedure, parametros);
        }
    }
}