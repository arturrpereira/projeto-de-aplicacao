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
    public partial class ServiçoView : Form
    {
        public ServiçoView()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ServiçoView_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_dsc_servico.Enabled = true;
            txb_valor_servico.Enabled = true;
        }

        private void txb_valor_servico_TextChanged(object sender, EventArgs e)
        {

        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_servico;

            if (txb_id_servico.Text != "")
            {
                id_servico = Int32.Parse(txb_id_servico.Text);
            }
            else
            {
                id_servico = 0;
            }
            var desc_servico = txb_dsc_servico.Text;
            var valor_servico = Convert.ToDouble(txb_valor_servico.Text);

            ServicoController controller = new ServicoController();

            try
            {
                controller.save(id_servico, desc_servico, valor_servico);
                MessageBox.Show("Serviço Cadastrado com sucesso!");
                txb_dsc_servico.Text = "";
                txb_valor_servico.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_servico;

            if (txb_id_servico.Text != null)
            {
                id_servico = Int32.Parse(txb_id_servico.Text);
            }
            else
            {
                id_servico = 0;
            }
            var desc_servico = txb_dsc_servico.Text;
            var valor_servico = Convert.ToDouble(txb_valor_servico.Text);

            ServicoController controller = new ServicoController();

            try
            {
                controller.save(id_servico, desc_servico, valor_servico);
                MessageBox.Show("Serviço atualizado com sucesso!");
                txb_dsc_servico.Text = "";
                txb_valor_servico.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O serviço a seguir será deletado: " + txb_dsc_servico.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_servico = Int32.Parse(txb_id_servico.Text);

                ServicoController controller = new ServicoController();

                try
                {
                    controller.delete(id_servico);
                    txb_id_servico.Text = "";
                    txb_dsc_servico.Text = "";
                    txb_valor_servico.Text = "";

                    MessageBox.Show("Servico deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar pet: " + ex);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_servico.Text = "";
            txb_dsc_servico.Text = "";
            txb_valor_servico.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buscar_servico.Text == "")
            {
                MessageBox.Show("Favor preencher o campo para efetuar busca!");
            }
            else
            {
                var id_servico = Int32.Parse(buscar_servico.Text);

                ServicoController controller = new ServicoController();

                var teste = controller.buscar(id_servico);

                var model = teste;

                if (teste.desc_servico == null)
                {
                    MessageBox.Show("Serviço não encontrado!");
                }
                else
                {
                    MessageBox.Show("Serviço encontrado com sucesso!");
                    txb_id_servico.Text = Convert.ToString(teste.id_servico);
                    txb_dsc_servico.Text = teste.desc_servico;
                    txb_valor_servico.Text = Convert.ToString(teste.valor_servico);

                    txb_id_servico.Enabled = true;
                    txb_dsc_servico.Enabled = true;
                    txb_valor_servico.Enabled = true;
                }
            }
        }

        private void btn_exibirdados_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Servico ORDER BY id_servico";
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
