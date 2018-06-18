using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace API.Util
{
    public class Parametros
    {
        private string _nomeProcedure;
        private List<SqlParameter> parametros;

        public Parametros(string nomeProcedure)
        {
            _nomeProcedure = nomeProcedure;
            parametros = new List<SqlParameter>();
        }

        public void Add(string nome, object valor)
        {
            parametros.Add(new SqlParameter() { Value = valor, ParameterName = nome });
        }

        public SqlParameter[] GetParametros()
        {
            return parametros.ToArray();
        }

        public string ToText()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_nomeProcedure);
            builder.Append(" ");
            parametros.ForEach(p => {
                builder.AppendFormat("@{0}, ", p.ParameterName);
            });            
            if (builder.Length > 0)
                builder.Remove(builder.Length - 2, 2);
            return builder.ToString();
        }
    }
}