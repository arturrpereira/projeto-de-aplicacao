using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PA.db;
using PA.Controller;

namespace PA.View
{
    public partial class Funcionario_Servico_View : Form
    {
        public Funcionario_Servico_View()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchServico ListarServico = new SearchServico();
            ListarServico.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchFuncionario ListarFuncionario = new SearchFuncionario();
            ListarFuncionario.ShowDialog();
        }

        private void txb_id_servico_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_id_servico.Enabled = true;
            txb_id_funcionario.Enabled = true;
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO servico_has_funcionario (fk_id_servico, fk_id_funcionario) " +
                                             "VALUES (@fk_id_servico, @fk_id_funcionario)";

            var id_servico = Int32.Parse(txb_id_servico.Text);
            var id_funcionario = Int32.Parse(txb_id_funcionario.Text);



            command.Parameters.AddWithValue("@fk_id_servico", id_servico);
            command.Parameters.AddWithValue("@fk_id_funcionario", id_funcionario);

            FuncionarioController funcionarioController = new FuncionarioController();
            ServicoController servicoController = new ServicoController();
            
            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Funcionário: " + funcionarioController.buscar(id_funcionario).nome_funcionario + " pode prestar o serviço: " + servicoController.buscar(id_servico).desc_servico);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar ligação: " + ex);
            }
            

            txb_id_funcionario.Text = "";
            txb_id_servico.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_funcionario.Text = "";
            txb_id_servico.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM servico_has_funcionario";
            NpgsqlDataReader dr = con.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Dados não cadastrados ainda!");
                dataGridView1.DataSource = null;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM servico_has_funcionario WHERE fk_id_servico=@fk_id_servico AND fk_id_funcionario=@fk_id_funcionario";

            var id_servico = Int32.Parse(txb_id_servico.Text);
            var id_funcionario = Int32.Parse(txb_id_funcionario.Text);

            command.Parameters.AddWithValue("@fk_id_servico", id_servico);
            command.Parameters.AddWithValue("@fk_id_funcionario", id_funcionario);

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Ligação excluída com sucesso!");
                txb_id_funcionario.Text = "";
                txb_id_servico.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir ligação: " + ex);
            }
        }
    }
}
