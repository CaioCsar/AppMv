using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace ProjetoRefeicao
{
    public partial class Form1 : Form
    {
        private DAO.Conexao db;
        private Modelo.Pessoa cruds;
        private Int32 catchRowIndex;

        //mover tela
        bool mover = false;
        Point posicaoInicial;

        public Form1()
        {
            InitializeComponent();
        }

        private void carregarDados()
        {
            db = new DAO.Conexao();
            dataGridView1.DataSource = null; // cria datagrid vazia
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            string connectionString = db.getConnectionString();
            string query = "SELECT * FROM pessoa";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    try
                    {
                        DataTable dataTable= new DataTable();
                        adapter.Fill(dataTable);
                        for(int i = 0; i<dataTable.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3]);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
            }
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {

            // dados da interface coletados
            string nomeApp = txtnome.Text;
            Int64 cpfApp = Int64.Parse(txtcpf.Text);
            string refeicaoApp = txtref.Text;

            try
            {
                cruds = new Modelo.Pessoa();
                cruds.nome = nomeApp;
                cruds.cpf = cpfApp;
                cruds.refeicao = refeicaoApp;
                cruds.Inserir();
                dataGridView1.Rows.Add(nomeApp, cpfApp, refeicaoApp, null);

                //limpar os campos
                txtnome.Text = "";
                txtcpf.Text = "";
                txtref.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro ao realizar a operação", "Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMostrarTabela_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1087, 514);
            btnOcultarTabela.Show();
            btnMostrarTabela.Hide();
        }

        private void btnOcultarTabela_Click(object sender, EventArgs e)
        {
            this.Size = new Size(634, 514);
            btnOcultarTabela.Hide();
            btnMostrarTabela.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(634, 514);
            carregarDados();
        }

        // MOVE, BOTAO PRESSIONADO
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mover = true;
            posicaoInicial = new Point(e.X, e.Y);
        }

        // MOVER, BOTAO APOS SER SOLTO
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        // MOVER, IDENTIFICAR CLICK DO MOUSE DURANTE O TRAJETO E IDENTIFICAR A POSICAO FINAL
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                Point novo = PointToScreen(e.Location);
                Location = new Point(novo.X - posicaoInicial.X, novo.Y - posicaoInicial.Y);
            }
        }

        private void btnatualizar_Click(object sender, EventArgs e)
        {
            carregarDados();
        }
    }
}
