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
    public partial class Material_ServicoView : Form
    {
        public Material_ServicoView()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchMaterial ListarMaterial = new SearchMaterial();
            ListarMaterial.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchServico ListarServico = new SearchServico();
            ListarServico.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_id_material.Enabled = true;
            txb_id_servico.Enabled = true;
            txb_qtd.Enabled = true;
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO material_has_servico (fk_id_material, fk_id_servico, qtd_material) " +
                                             "VALUES (@fk_id_material, @fk_id_servico, @qtd_material)";

            var id_material = Int32.Parse(txb_id_material.Text);
            var id_servico = Int32.Parse(txb_id_servico.Text);
            var qtd_material = Int32.Parse(txb_qtd.Text);

            command.Parameters.AddWithValue("@fk_id_material", id_material);
            command.Parameters.AddWithValue("@fk_id_servico", id_servico);
            command.Parameters.AddWithValue("@qtd_material", qtd_material);

            MaterialController materialController = new MaterialController();
            ServicoController servicoController = new ServicoController();

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Material: " + materialController.buscar(id_material).desc_material + " utilizado no serviço: " + servicoController.buscar(id_servico).desc_servico);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar ligação: " + ex);
            }

            txb_id_material.Text = "";
            txb_id_servico.Text = "";
            txb_qtd.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM material_has_servico WHERE fk_id_material=@fk_id_material AND fk_id_servico=@fk_id_servico";

            var id_material = Int32.Parse(txb_id_material.Text);
            var id_servico = Int32.Parse(txb_id_servico.Text);

            command.Parameters.AddWithValue("@fk_id_material", id_material);
            command.Parameters.AddWithValue("@fk_id_servico", id_servico);

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Ligação excluída com sucesso!");

                txb_id_material.Text = "";
                txb_id_servico.Text = "";
                txb_qtd.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir ligação: " + ex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_material.Text = "";
            txb_id_servico.Text = "";
            txb_qtd.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM material_has_servico";
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
    }
}
