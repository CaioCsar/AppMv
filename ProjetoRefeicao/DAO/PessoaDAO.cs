using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoRefeicao.DAO
{
    class PessoaDAO
    {
        private DAO.Conexao db;
        private MySqlConnection con; // biblioteca mysql instanciada


        public PessoaDAO()
        {

        } //construtor vazio da classe dao

        public void InserirDados(String nome, Int64 cpf, String refeicao)
        {
            con = new MySqlConnection();
            db = new DAO.Conexao();
            con.ConnectionString = db.getConnectionString();
            String query = "INSERT INTO pessoa (nome, cpf, refeicao) VALUES (?nome, ?cpf, ?refeicao)";

            try 
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cpf", cpf);
                cmd.Parameters.AddWithValue("?refeicao", refeicao);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um Erro: \n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void AtualizarDados(String nome, Int64 cpf, String refeicao, Int32 id)
        {
            con = new MySqlConnection();
            db = new DAO.Conexao();
            con.ConnectionString = db.getConnectionString();
            String query = " UPDATE pessoa SET nome = ?nome, cpf = ?cpf, refeicao = ?refeicao WHERE id = ?id";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?nome", nome);
                cmd.Parameters.AddWithValue("?cpf", cpf);
                cmd.Parameters.AddWithValue("?refeicao", refeicao);
                cmd.Parameters.AddWithValue("?id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void RemoverDados(Int32 id)
        {
            con = new MySqlConnection();
            db = new DAO.Conexao();
            con.ConnectionString = db.getConnectionString();
            String query = " DELETE FROM pessoa WHERE id= ?id";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void SelecionarDados()
        {
            con = new MySqlConnection();
            db = new DAO.Conexao();
            con.ConnectionString = db.getConnectionString();
            String query = " SELECT * FROM pessoa";

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }

        public void VerificarDuplicata(String refeicao, Int32 id)
        {
            con = new MySqlConnection();
            db = new DAO.Conexao();
            con.ConnectionString = db.getConnectionString();
            String query = " SELECT CASE ?refeicao THEN ?refeicao"; // FALTA FINALIZAR, FUNCAO DE VERIFICAR SE EXISTEM DUAS COMIDAS IGUAIS, IMPEDINDO DE SE REPETIR NA HORA DO CADASTRO

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("?refeicao", refeicao);
                cmd.Parameters.AddWithValue("?id", id);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
