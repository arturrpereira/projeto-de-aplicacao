using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PA.Controller;
using Npgsql;
using PA.db;

namespace PA.View
{
    public partial class MaterialView : Form
    {
        public MaterialView()
        {
            InitializeComponent();
        }

        private void MaterialView_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_dsc_material.Enabled = true;
            txb_valor_material.Enabled = true;
            txb_qtd_minima.Enabled = true;
            txb_qtd_maxima.Enabled = true;
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_material;

            if (txb_id_material.Text != "")
            {
                id_material = Int32.Parse(txb_id_material.Text);
            }
            else
            {
                id_material = 0;
            }
            var desc_material = txb_dsc_material.Text;
            var preco_material = Int32.Parse(txb_valor_material.Text);
            var qtd_minimo = Convert.ToDouble(txb_qtd_minima.Text);
            var qtd_maximo = Convert.ToDouble(txb_qtd_maxima.Text);
           
            MaterialController controller = new MaterialController();

            try
            {
                controller.save(id_material, desc_material, preco_material, (int)qtd_minimo, (int)qtd_maximo);
                MessageBox.Show("Material Cadastrado com sucesso!");
                txb_id_material.Text = "";
                txb_dsc_material.Text = "";
                txb_valor_material.Text = "";
                txb_qtd_minima.Text = "";
                txb_qtd_maxima.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_material;

            if (txb_id_material.Text != "")
            {
                id_material = Int32.Parse(txb_id_material.Text);
            }
            else
            {
                id_material = 0;
            }
            var desc_material = txb_dsc_material.Text;
            var preco_material = Int32.Parse(txb_valor_material.Text);
            var qtd_minimo = Convert.ToDouble(txb_qtd_minima.Text);
            var qtd_maximo = Convert.ToDouble(txb_qtd_maxima.Text);

            MaterialController controller = new MaterialController();

            try
            {
                controller.save(id_material, desc_material, preco_material, qtd_minimo, qtd_maximo);
                MessageBox.Show("Material atualizado com sucesso!");
                txb_id_material.Text = "";
                txb_dsc_material.Text = "";
                txb_valor_material.Text = "";
                txb_qtd_minima.Text = "";
                txb_qtd_maxima.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O material a seguir será deletado: " + txb_dsc_material.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_material = Int32.Parse(txb_id_material.Text);

                MaterialController controller = new MaterialController();

                try
                {
                    controller.delete(id_material);
                    txb_id_material.Text = "";
                    txb_dsc_material.Text = "";
                    txb_valor_material.Text = "";
                    txb_qtd_minima.Text = "";
                    txb_qtd_maxima.Text = "";

                    MessageBox.Show("Material deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar material: " + ex);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_material.Text = "";
            txb_dsc_material.Text = "";
            txb_valor_material.Text = "";
            txb_qtd_minima.Text = "";
            txb_qtd_maxima.Text = "";
        }

        private void btn_exibirdados_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Material ORDER BY id_material";
            NpgsqlDataReader dr = con.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buscar_material.Text == "")
            {
                MessageBox.Show("Favor preencher o campo para efetuar busca!");
            }
            else
            {
                var id_material = Int32.Parse(buscar_material.Text);

                MaterialController controller = new MaterialController();

                var teste = controller.buscar(id_material);

                if (teste.desc_material == null)
                {
                    MessageBox.Show("Material não encontrado!");
                }
                else
                {
                    MessageBox.Show("Material encontrado com sucesso!");
                    txb_id_material.Text = Convert.ToString(teste.id_material);
                    txb_dsc_material.Text = teste.desc_material;
                    txb_valor_material.Text = Convert.ToString(teste.preco_material);
                    txb_qtd_minima.Text = Convert.ToString(teste.qtd_minima);
                    txb_qtd_maxima.Text = Convert.ToString(teste.qtd_maxima);

                    txb_dsc_material.Enabled = true;
                    txb_valor_material.Enabled = true;
                    txb_qtd_minima.Enabled = true;
                    txb_qtd_maxima.Enabled = true;
                }
            }
        }
    }
}
