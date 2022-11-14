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
    public partial class ClienteView : Form
    {
        public ClienteView()
        {
            InitializeComponent();
        }

        private void ClienteView_Load(object sender, EventArgs e)
        {

        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_cliente;

            if (txb_id_cliente.Text != "")
            {
                id_cliente = Int32.Parse(txb_id_cliente.Text);
            }
            else
            {
                id_cliente = 0;
            }
            var nome_cliente = txb_nome_cliente.Text;
            var rg_cliente = txb_rg_cliente.Text;
            var cpf_cliente = txb_cpf_cliente.Text;
            var datanasc_cliente = txb_datanasc_cliente.Text;
            var telefone_cliente = txb_telefone_cliente.Text;
            var email_cliente = txb_email_cliente.Text;
            var endereco_cliente = txb_endereco_cliente.Text;
            var numero_endereco_cliente = Int32.Parse(txb_numero_cliente.Text);
            var bairro_cliente = txb_bairro_cliente.Text;

            ClienteController controller = new ClienteController();

            try
            {
                controller.save(id_cliente, nome_cliente, rg_cliente, cpf_cliente, datanasc_cliente, telefone_cliente, email_cliente, endereco_cliente, numero_endereco_cliente, bairro_cliente);
                MessageBox.Show("Cliente Atualizado com sucesso!");
                txb_nome_cliente.Text = "";
                txb_rg_cliente.Text = "";
                txb_cpf_cliente.Text = "";
                txb_datanasc_cliente.Text = "";
                txb_telefone_cliente.Text = "";
                txb_email_cliente.Text = "";
                txb_endereco_cliente.Text = "";
                txb_numero_cliente.Text = "";
                txb_bairro_cliente.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_nome_cliente.Enabled = true;
            txb_rg_cliente.Enabled = true;
            txb_cpf_cliente.Enabled = true;
            txb_datanasc_cliente.Enabled = true;
            txb_telefone_cliente.Enabled = true;
            txb_email_cliente.Enabled = true;
            txb_endereco_cliente.Enabled = true;
            txb_numero_cliente.Enabled = true;
            txb_bairro_cliente.Enabled = true;
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_cliente;

            if (txb_id_cliente.Text != null)
            {
                id_cliente = Int32.Parse(txb_id_cliente.Text);
            }
            else
            {
                id_cliente = 0;
            }
            var nome_cliente = txb_nome_cliente.Text;
            var rg_cliente = txb_rg_cliente.Text;
            var cpf_cliente = txb_cpf_cliente.Text;
            var datanasc_cliente = txb_datanasc_cliente.Text;
            var telefone_cliente = txb_telefone_cliente.Text;
            var email_cliente = txb_email_cliente.Text;
            var endereco_cliente = txb_endereco_cliente.Text;
            var numero_endereco_cliente = Int32.Parse(txb_numero_cliente.Text);
            var bairro_cliente = txb_bairro_cliente.Text;

            ClienteController controller = new ClienteController();

            try
            {
                controller.save(id_cliente, nome_cliente, rg_cliente, cpf_cliente, datanasc_cliente, telefone_cliente, email_cliente, endereco_cliente, numero_endereco_cliente, bairro_cliente);
                MessageBox.Show("Cliente Atualizado com sucesso!");
                txb_nome_cliente.Text = "";
                txb_rg_cliente.Text = "";
                txb_cpf_cliente.Text = "";
                txb_datanasc_cliente.Text = "";
                txb_telefone_cliente.Text = "";
                txb_email_cliente.Text = "";
                txb_endereco_cliente.Text = "";
                txb_numero_cliente.Text = "";
                txb_bairro_cliente.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro" + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O cliente a seguir será deletado: " + txb_nome_cliente.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_cliente = Int32.Parse(txb_id_cliente.Text);

                ServicoController controller = new ServicoController();

                try
                {
                    controller.delete(id_cliente);
                    txb_id_cliente.Text = "";
                    txb_nome_cliente.Text = "";
                    txb_rg_cliente.Text = "";
                    txb_cpf_cliente.Text = "";
                    txb_datanasc_cliente.Text = "";
                    txb_telefone_cliente.Text = "";
                    txb_email_cliente.Text = "";
                    txb_endereco_cliente.Text = "";
                    txb_numero_cliente.Text = "";
                    txb_bairro_cliente.Text = "";

                    MessageBox.Show("Cliente deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar cliente: " + ex);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buscar_cliente.Text == "")
            {
                MessageBox.Show("Favor preencher o campo para efetuar busca!");
            }
            else
            {
                var id_cliente = Int32.Parse(buscar_cliente.Text);

                ClienteController controller = new ClienteController();

                var teste = controller.buscar(id_cliente);
                var model = teste;

                if (teste.nome_cliente == null)
                {
                    MessageBox.Show("Cliente não encontrado!");
                }
                else
                {
                    MessageBox.Show("Cliente encontrado com sucesso!");
                    txb_id_cliente.Text = Convert.ToString(model.id_cliente);
                    txb_nome_cliente.Text = model.nome_cliente;
                    txb_rg_cliente.Text = model.rg_cliente;
                    txb_cpf_cliente.Text = model.cpf_cliente;
                    txb_datanasc_cliente.Text = model.dataNasc_cliente;
                    txb_telefone_cliente.Text = model.telefone_cliente;
                    txb_email_cliente.Text = model.email_cliente;
                    txb_endereco_cliente.Text = model.endereco_cliente;
                    txb_numero_cliente.Text = Convert.ToString(model.numero_endereco_cliente);
                    txb_bairro_cliente.Text = model.bairro_cliente;
                  
                    txb_nome_cliente.Enabled = true;
                    txb_rg_cliente.Enabled = true;
                    txb_cpf_cliente.Enabled = true;
                    txb_datanasc_cliente.Enabled = true;
                    txb_telefone_cliente.Enabled = true;
                    txb_email_cliente.Enabled = true;
                    txb_endereco_cliente.Enabled = true;
                    txb_numero_cliente.Enabled = true;
                    txb_bairro_cliente.Enabled = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            txb_id_cliente.Text = "";
            txb_nome_cliente.Text = "";
            txb_rg_cliente.Text = "";
            txb_cpf_cliente.Text = "";
            txb_datanasc_cliente.Text = "";
            txb_telefone_cliente.Text = "";
            txb_email_cliente.Text = "";
            txb_endereco_cliente.Text = "";
            txb_numero_cliente.Text = "";
            txb_bairro_cliente.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Cliente ORDER BY id_cliente";
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
