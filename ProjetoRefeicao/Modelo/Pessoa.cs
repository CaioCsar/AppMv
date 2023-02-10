using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRefeicao.Modelo
{
    class Pessoa
    {
        private String _nome;
        private Int64 _cpf;
        private String _refeicao;
        private Int32 _id;

        private DAO.PessoaDAO cdao;

        public Pessoa() { }

        public String nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public Int64 cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public String refeicao
        {
            get { return _refeicao; }
            set { _refeicao = value; }
        }

        public Int32 id
        {
            get { return _id; }
            set { _id = value; }
        }

        public void Atualizar()
        {
            cdao = new DAO.PessoaDAO();
            cdao.AtualizarDados(nome, cpf, refeicao, id);
        }

        public void Inserir()
        {
            cdao = new DAO.PessoaDAO();
            cdao.InserirDados(nome, cpf, refeicao);
        }

        public void Remover()
        {
            cdao = new DAO.PessoaDAO();
            cdao.RemoverDados(id);
        }
    }
}
