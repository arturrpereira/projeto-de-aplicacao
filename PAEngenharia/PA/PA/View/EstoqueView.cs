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
    public partial class EstoqueView : Form
    {
        public EstoqueView()
        {
            InitializeComponent();
        }

        private void EstoqueView_Load(object sender, EventArgs e)
        {

        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_estoque;

            if (txb_id_estoque.Text != "")
            {
                id_estoque = Int32.Parse(txb_id_estoque.Text);
            }
            else
            {
                id_estoque = 0;
            }
            var desc_estoque = txb_dsc_estoque.Text;
            
            EstoqueController controller = new EstoqueController();

            try
            {
                controller.save(id_estoque, desc_estoque);
                MessageBox.Show("Estoque Cadastrado com sucesso!");
                txb_dsc_estoque.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_dsc_estoque.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_estoque;

            if (txb_id_estoque.Text != null)
            {
                id_estoque = Int32.Parse(txb_id_estoque.Text);
            }
            else
            {
                id_estoque = 0;
            }
            var desc_estoque = txb_dsc_estoque.Text;
            
            EstoqueController controller = new EstoqueController();

            try
            {
                controller.save(id_estoque, desc_estoque);
                MessageBox.Show("Estoque atualizado com sucesso!");
                txb_id_estoque.Text = "";
                txb_dsc_estoque.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O estoqe a seguir será deletado: " + txb_dsc_estoque.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_servico = Int32.Parse(txb_id_estoque.Text);

                EstoqueController controller = new EstoqueController();

                try
                {
                    controller.delete(id_servico);
                    txb_id_estoque.Text = "";
                    txb_dsc_estoque.Text = "";

                    MessageBox.Show("Estoque deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar pet: " + ex);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_estoque.Text = "";
            txb_dsc_estoque.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (buscar_estoque.Text == "")
            {
                MessageBox.Show("Favor preencher o campo para efetuar busca!");
            }
            else
            {
                var id_estoque = Int32.Parse(buscar_estoque.Text);

                EstoqueController controller = new EstoqueController();

                var teste = controller.buscar(id_estoque);

                var model = teste;

                if (teste.desc_estoque == null)
                {
                    MessageBox.Show("Estoque não encontrado!");
                }
                else
                {
                    MessageBox.Show("Estoque encontrado com sucesso!");
                    txb_id_estoque.Text = Convert.ToString(model.id_estoque);
                    txb_dsc_estoque.Text = model.desc_estoque;

                    txb_dsc_estoque.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Estoque ORDER BY id_estoque";
            NpgsqlDataReader dr = con.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;


            }
        }
    }
}
