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
    public partial class FornecedorView : Form
    {
        public FornecedorView()
        {
            InitializeComponent();
        }

        private void FornecedorView_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_nome_fornecedor.Enabled = true;
            txb_razao_social.Enabled = true;
            txb_cnpj_fornecedor.Enabled = true;
            txb_insc_estadual_fornecedor.Enabled = true;
            txb_tipo_contribuinte_fornecedor.Enabled = true;
            txb_email_fornecedor.Enabled = true;
            txb_resp_fornecedor.Enabled = true;
            txb_contato_responsavel.Enabled = true;
            txb_telefone_fornecedor.Enabled = true;
            txb_endereco_fornecedor.Enabled = true;
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_fornecedor;

            if (txb_id_fornecedor.Text != "")
            {
                id_fornecedor = Int32.Parse(txb_id_fornecedor.Text);
            }
            else
            {
                id_fornecedor = 0;
            }
            var nomefantasia = txb_nome_fornecedor.Text;
            var razaosocial = txb_razao_social.Text;
            var cnpjfornecedor = txb_cnpj_fornecedor.Text;
            var inscestadual = txb_insc_estadual_fornecedor.Text;
            var tipocontribuinte = txb_tipo_contribuinte_fornecedor.Text;
            var email_fornecedor = txb_email_fornecedor.Text;
            var responsavel_fornecedor = txb_resp_fornecedor.Text;
            var contato_responsavel = txb_contato_responsavel.Text;
            var telefone_fornecedor = txb_telefone_fornecedor.Text;
            var endereco_fornecedor = txb_endereco_fornecedor.Text;


            FornecedorController controller = new FornecedorController();

            try
            {
                controller.save(nomefantasia, razaosocial, cnpjfornecedor, inscestadual, tipocontribuinte, email_fornecedor, responsavel_fornecedor, contato_responsavel, telefone_fornecedor, endereco_fornecedor);
                MessageBox.Show("Fornecedor Cadastrado com sucesso!");
                txb_nome_fornecedor.Text = "";
                txb_razao_social.Text = "";
                txb_cnpj_fornecedor.Text = "";
                txb_insc_estadual_fornecedor.Text = "";
                txb_tipo_contribuinte_fornecedor.Text = "";
                txb_email_fornecedor.Text = "";
                txb_resp_fornecedor.Text = "";
                txb_contato_responsavel.Text = "";
                txb_telefone_fornecedor.Text = "";
                txb_endereco_fornecedor.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_fornecedor;

            if (txb_id_fornecedor.Text != "")
            {
                id_fornecedor = Int32.Parse(txb_id_fornecedor.Text);
            }
            else
            {
                id_fornecedor = 0;
            }
            var nomefantasia = txb_nome_fornecedor.Text;
            var razaosocial = txb_razao_social.Text;
            var cnpjfornecedor = txb_cnpj_fornecedor.Text;
            var inscestadual = txb_insc_estadual_fornecedor.Text;
            var tipocontribuinte = txb_tipo_contribuinte_fornecedor.Text;
            var email_fornecedor = txb_email_fornecedor.Text;
            var responsavel_fornecedor = txb_resp_fornecedor.Text;
            var contato_responsavel = txb_contato_responsavel.Text;
            var telefone_fornecedor = txb_telefone_fornecedor.Text;
            var endereco_fornecedor = txb_endereco_fornecedor.Text;


            FornecedorController controller = new FornecedorController();

            try
            {
                controller.save(nomefantasia, razaosocial, cnpjfornecedor, inscestadual, tipocontribuinte, email_fornecedor, responsavel_fornecedor, contato_responsavel, telefone_fornecedor, endereco_fornecedor);
                MessageBox.Show("Fornecedor Cadastrado com sucesso!");
                txb_id_fornecedor.Text = "";
                txb_nome_fornecedor.Text = "";
                txb_razao_social.Text = "";
                txb_cnpj_fornecedor.Text = "";
                txb_insc_estadual_fornecedor.Text = "";
                txb_tipo_contribuinte_fornecedor.Text = "";
                txb_email_fornecedor.Text = "";
                txb_resp_fornecedor.Text = "";
                txb_contato_responsavel.Text = "";
                txb_telefone_fornecedor.Text = "";
                txb_endereco_fornecedor.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O fornecedor a seguir será deletado: " + txb_nome_fornecedor.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_fornecedor = Int32.Parse(txb_id_fornecedor.Text);

                FornecedorController controller = new FornecedorController();

                try
                {
                    controller.delete(id_fornecedor);
                    txb_id_fornecedor.Text = "";
                    txb_nome_fornecedor.Text = "";
                    txb_razao_social.Text = "";
                    txb_cnpj_fornecedor.Text = "";
                    txb_insc_estadual_fornecedor.Text = "";
                    txb_tipo_contribuinte_fornecedor.Text = "";
                    txb_email_fornecedor.Text = "";
                    txb_resp_fornecedor.Text = "";
                    txb_contato_responsavel.Text = "";
                    txb_telefone_fornecedor.Text = "";
                    txb_endereco_fornecedor.Text = "";

                    MessageBox.Show("Fornecedor deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar fornecedor: " + ex);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_fornecedor.Text = "";
            txb_nome_fornecedor.Text = "";
            txb_razao_social.Text = "";
            txb_cnpj_fornecedor.Text = "";
            txb_insc_estadual_fornecedor.Text = "";
            txb_tipo_contribuinte_fornecedor.Text = "";
            txb_email_fornecedor.Text = "";
            txb_resp_fornecedor.Text = "";
            txb_contato_responsavel.Text = "";
            txb_telefone_fornecedor.Text = "";
            txb_endereco_fornecedor.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buscar_fornecedor.Text == "")
            {
                MessageBox.Show("Favor preencher o campo para efetuar busca!");
            }
            else
            {
                var id_fornecedor = Int32.Parse(buscar_fornecedor.Text);

                FornecedorController controller = new FornecedorController();

                var model = controller.buscar(id_fornecedor);

                if (model.nomeFantasia == null)
                {
                    MessageBox.Show("Fornecedor não encontrado!");
                }
                else
                {
                    MessageBox.Show("Fornecedor encontrado com sucesso!");
                    txb_id_fornecedor.Text = Convert.ToString(model.id_fornecedor);
                    txb_nome_fornecedor.Text = model.nomeFantasia;
                    txb_razao_social.Text = model.razaoSocial;
                    txb_cnpj_fornecedor.Text = model.CNPJFornecedor;
                    txb_insc_estadual_fornecedor.Text = model.inscEstadual;
                    txb_tipo_contribuinte_fornecedor.Text = model.tipoContribuinte;
                    txb_email_fornecedor.Text = model.email_fornecedor;
                    txb_resp_fornecedor.Text = model.responsavel_fornecedor;
                    txb_contato_responsavel.Text = model.contato_responsavel;
                    txb_telefone_fornecedor.Text = model.telefone_fornecedor;
                    txb_endereco_fornecedor.Text = model.endereco_fornecedor;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Fornecedor ORDER BY id_fornecedor";
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
