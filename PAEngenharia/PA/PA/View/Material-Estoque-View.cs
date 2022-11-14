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
    public partial class Material_Estoque_View : Form
    {
        public Material_Estoque_View()
        {
            InitializeComponent();
        }

        private void Material_Estoque_View_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchMaterial ListarMaterial = new SearchMaterial();
            ListarMaterial.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchEstoque ListarEstoque = new SearchEstoque();
            ListarEstoque.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM material_has_estoque WHERE fk_id_material=@fk_id_material AND fk_id_estoque=@fk_id_estoque";

            var id_material = Int32.Parse(txb_id_material.Text);
            var id_estoque = Int32.Parse(txb_id_estoque.Text);

            command.Parameters.AddWithValue("@fk_id_material", id_material);
            command.Parameters.AddWithValue("@fk_id_estoque", id_estoque);

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Ligação excluída com sucesso!");

                txb_id_estoque.Text = "";
                txb_id_material.Text = "";
                txb_qtde_estoque.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir ligação: " + ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_id_estoque.Enabled = true;
            txb_id_material.Enabled = true;
            txb_qtde_estoque.Enabled = true;
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO material_has_estoque (quantidade_estoque, fk_id_material, fk_id_estoque) " +
                                             "VALUES (@quantidade_estoque, @fk_id_material, @fk_id_estoque)";

            var id_material = Int32.Parse(txb_id_material.Text);
            var id_estoque = Int32.Parse(txb_id_estoque.Text);
            var quantidade_estoque = Int32.Parse(txb_qtde_estoque.Text);

            command.Parameters.AddWithValue("@quantidade_estoque", quantidade_estoque);
            command.Parameters.AddWithValue("@fk_id_material", id_material);
            command.Parameters.AddWithValue("@fk_id_estoque", id_estoque);

            MaterialController materialController = new MaterialController();
            EstoqueController estoqueController = new EstoqueController();

            try
            {
                ConnectionDB.CRUD(command);
                MessageBox.Show("Material: " + materialController.buscar(id_material).desc_material + " ligado ao estoque: " + estoqueController.buscar(id_estoque).desc_estoque);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar ligação: " + ex);
            }

            txb_qtde_estoque.Text = "";
            txb_id_estoque.Text = "";
            txb_id_material.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_estoque.Text = "";
            txb_id_material.Text = "";
            txb_qtde_estoque.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM material_has_estoque";
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
