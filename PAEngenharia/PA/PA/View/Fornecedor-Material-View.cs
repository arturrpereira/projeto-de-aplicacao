using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PA.db;
using Npgsql;
using PA.Controller;

namespace PA.View
{
    public partial class Fornecedor_Material_View : Form
    {
        public Fornecedor_Material_View()
        {
            InitializeComponent();
        }

        private void Fornecedor_Material_View_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_id_fornecedor.Enabled = true;
            txb_id_material.Enabled = true;
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO material_has_fornecedor (fk_id_material, fk_id_fornecedor) " +
                                             "VALUES (@fk_id_material, @fk_id_fornecedor)";

            var id_material = Int32.Parse(txb_id_material.Text);
            var id_fornecedor = Int32.Parse(txb_id_fornecedor.Text);

            command.Parameters.AddWithValue("@fk_id_material", id_material);
            command.Parameters.AddWithValue("@fk_id_fornecedor", id_fornecedor);

            MaterialController materialController = new MaterialController();
            FornecedorController fornecedorController = new FornecedorController();

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("O fornecedor: " + fornecedorController.buscar(id_fornecedor).nomeFantasia + " está fornecendo o material: " + materialController.buscar(id_material).desc_material);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar ligação: " + ex);
            }

            txb_id_fornecedor.Text = "";
            txb_id_material.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_material.Text = "";
            txb_id_fornecedor.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM material_has_fornecedor";
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchMaterial ListarMaterial = new SearchMaterial();
            ListarMaterial.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM material_has_fornecedor WHERE fk_id_material=@fk_id_material AND fk_id_fornecedor=@fk_id_fornecedor";

            var id_material = Int32.Parse(txb_id_material.Text);
            var id_fornecedor = Int32.Parse(txb_id_fornecedor.Text);

            command.Parameters.AddWithValue("@fk_id_material", id_material);
            command.Parameters.AddWithValue("@fk_id_fornecedor", id_fornecedor);

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Ligação excluída com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir ligação: " + ex);
            }
       
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchFornecedor ListarFornecedor = new SearchFornecedor();
            ListarFornecedor.ShowDialog();
        }
    }
}
