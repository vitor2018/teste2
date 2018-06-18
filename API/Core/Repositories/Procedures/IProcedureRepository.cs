using System.Collections.Generic;
using System.Data.SqlClient;

namespace API.Core.Repositories
{
    public interface IProcedureRepository<T> where T : class
    {        
        IEnumerable<T> Proc_Retorno(string procedure, SqlParameter[] parametros);
    }
}