using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProjetoRefeicao.DAO
{
    class Conexao
    {

        private String connectionString;//string de conexão banco de dados.

        public String getConnectionString()//função para chamada de conexão com bando de dados.
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProjetoRefeicao.Properties.Settings.crudConnectionString"].ConnectionString;
            return connectionString;
        }
    }
}