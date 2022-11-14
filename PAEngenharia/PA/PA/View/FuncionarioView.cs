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
    public partial class procurar_funcionario : Form
    {
        public procurar_funcionario()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBoxRG_KeyPress(object sender, KeyPressEventArgs e)

        {

            if (!char.IsDigit(e.KeyChar))

            {
                e.Handled = true;

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {/*
            var nome_funcionario = txb_nome_funcionario.Text;
            var rg_funcionario = txb_rg_funcionario.Text;
            var cpf_funcionario = txb_cpf_funcionario.Text;
            var endereco_funcionario = txb_endereco_funcionario.Text;
            var numero_endereco_funcionario = nmr_numero_endereco.Value;
            var bairro_funcionario = txb_bairro_funcionario.Text;
            var dataAdmissao_funcionario = txb_dataAdmissao_funcionario.Text;
            var dataNasc_funcionario = txb_dataNasc_funcionario.Text;
            var genero_funcionario = txb_genero_funcionario.Text;
            var telefone_funcionario = txb_telefone_funcionario.Text;
            var fk_id_cargo = nmr_id_cargo.Value;

            FuncionarioController controller = new FuncionarioController();

            try
            {
                controller.save(nome_funcionario, rg_funcionario, cpf_funcionario, endereco_funcionario, (int)numero_endereco_funcionario, bairro_funcionario, dataAdmissao_funcionario, dataAdmissao_funcionario, genero_funcionario, telefone_funcionario, (int)fk_id_cargo);
                MessageBox.Show("Cadastrado com sucesso");
            }
            catch (Exception)
            {
                MessageBox.Show("ERRO: ");
            }*/
        }

        private void txb_endereco_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void funcionarios_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O funcionário a seguir será deletado: " + txb_nome_funcionario.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_funcionario = Int32.Parse(txb_id_funcionario.Text);


                FuncionarioController controller = new FuncionarioController();
                try
                {
                    controller.delete(id_funcionario);
                    txb_id_funcionario.Text = "";
                    txb_nome_funcionario.Text = "";
                    txb_rg_funcionario.Text = "";
                    txb_cpf_funcionario.Text = "";
                    cob_genero_funcionario.Text = "";
                    txb_datanasc_funcionario.Text = "";
                    txb_dataadmi_funcionario.Text = "";
                    txb_endereco_funcionario.Text = "";
                    txb_numero_residencia.Text = "";
                    txb_bairro_funcionario.Text = "";
                    txb_telefone_funcionario.Text = "";
                    txb_id_cargo.Text = "";
                    buscar_funcionario.Text = "";

                    MessageBox.Show("Funcionário deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar funcionário: " + ex);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            txb_nome_funcionario.Enabled = true;
            txb_rg_funcionario.Enabled = true;
            txb_cpf_funcionario.Enabled = true;
            cob_genero_funcionario.Enabled = true;
            txb_datanasc_funcionario.Enabled = true;
            txb_dataadmi_funcionario.Enabled = true;
            txb_endereco_funcionario.Enabled = true;
            txb_numero_residencia.Enabled = true;
            txb_bairro_funcionario.Enabled = true;
            txb_telefone_funcionario.Enabled = true;
            txb_id_cargo.Enabled = true;
           
        
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void enviar_funcionario_Click_1(object sender, EventArgs e)
        {
            int id_funcionario;

            if (txb_id_funcionario.Text != "")
            {
                id_funcionario = Int32.Parse(txb_id_funcionario.Text);
            }
            else
            {
                id_funcionario = 0;
            }
            var nome_funcionario = txb_nome_funcionario.Text;
            var rg_funcionario = txb_rg_funcionario.Text;
            var cpf_funcionario = txb_cpf_funcionario.Text;
            var genero_funcionario = cob_genero_funcionario.Text;
            var dataNasc_funcionario = txb_datanasc_funcionario.Text;
            var dataadm_funcionario = txb_dataadmi_funcionario.Text;
            var endereco_funcionario = txb_endereco_funcionario.Text;
            var numero_endereco_funcionario = Int32.Parse(txb_numero_residencia.Text);
            var bairro_funcionario = txb_bairro_funcionario.Text;
            var telefone_funcionario = txb_telefone_funcionario.Text;
            int fk_id_cargo = Int32.Parse(txb_id_cargo.Text);

            FuncionarioController controller = new FuncionarioController();

            try
            {
                controller.save(id_funcionario, nome_funcionario, rg_funcionario, cpf_funcionario, endereco_funcionario, numero_endereco_funcionario, bairro_funcionario, dataadm_funcionario, dataNasc_funcionario, genero_funcionario, telefone_funcionario, fk_id_cargo);
                MessageBox.Show("Funcionário Cadastrado com sucesso!");
                txb_nome_funcionario.Text = "";
                txb_rg_funcionario.Text = "";
                txb_cpf_funcionario.Text = "";
                cob_genero_funcionario.Text = "";
                txb_datanasc_funcionario.Text = "";
                txb_dataadmi_funcionario.Text = "";
                txb_endereco_funcionario.Text = "";
                txb_numero_residencia.Text = "";
                txb_bairro_funcionario.Text = "";
                txb_telefone_funcionario.Text = "";
                txb_id_cargo.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_funcionario;

            if (txb_id_funcionario.Text != null)
            {
                id_funcionario = Int32.Parse(txb_id_funcionario.Text);
            }
            else
            {
                id_funcionario = 0;
            }
            var nome_funcionario = txb_nome_funcionario.Text;
            var rg_funcionario = txb_rg_funcionario.Text;
            var cpf_funcionario = txb_cpf_funcionario.Text;
            var genero_funcionario = cob_genero_funcionario.Text;
            var dataNasc_funcionario = txb_datanasc_funcionario.Text;
            var dataadm_funcionario = txb_dataadmi_funcionario.Text;
            var endereco_funcionario = txb_endereco_funcionario.Text;
            var numero_endereco_funcionario = Int32.Parse(txb_numero_residencia.Text);
            var bairro_funcionario = txb_bairro_funcionario.Text;
            var telefone_funcionario = txb_telefone_funcionario.Text;
            int fk_id_cargo = Int32.Parse(txb_id_cargo.Text);

            FuncionarioController controller = new FuncionarioController();

            try
            {
                controller.save(id_funcionario, nome_funcionario, rg_funcionario, cpf_funcionario, endereco_funcionario, numero_endereco_funcionario, bairro_funcionario, dataadm_funcionario, dataNasc_funcionario, genero_funcionario, telefone_funcionario, fk_id_cargo);
                MessageBox.Show("Funcionário atualizado com sucesso!");
                txb_id_funcionario.Text = "";
                txb_nome_funcionario.Text = "";
                txb_rg_funcionario.Text = "";
                txb_cpf_funcionario.Text = "";
                cob_genero_funcionario.Text = "";
                txb_datanasc_funcionario.Text = "";
                txb_dataadmi_funcionario.Text = "";
                txb_endereco_funcionario.Text = "";
                txb_numero_residencia.Text = "";
                txb_bairro_funcionario.Text = "";
                txb_telefone_funcionario.Text = "";
                txb_id_cargo.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("erro" + ex);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var id_funcionario = Int32.Parse(buscar_funcionario.Text);

            FuncionarioController controller = new FuncionarioController();

            var teste = controller.buscar(id_funcionario).nome_funcionario;

            if (teste == null)
            {
                MessageBox.Show("Funcionário não encontrado!");
            }
            else
            {
                MessageBox.Show("Funcionário encontrado com sucesso!");
                txb_id_funcionario.Text = Convert.ToString(controller.buscar(id_funcionario).id_funcionario);
                txb_nome_funcionario.Text = controller.buscar(id_funcionario).nome_funcionario;
                txb_rg_funcionario.Text = controller.buscar(id_funcionario).rg_funcionario;
                txb_cpf_funcionario.Text = controller.buscar(id_funcionario).cpf_funcionario;
                cob_genero_funcionario.Text = controller.buscar(id_funcionario).genero_funcionario;
                txb_datanasc_funcionario.Text = controller.buscar(id_funcionario).dataNasc_funcionario;
                txb_dataadmi_funcionario.Text = controller.buscar(id_funcionario).dataAdmissao_funcionario;
                txb_endereco_funcionario.Text = controller.buscar(id_funcionario).endereco_funcionario;
                txb_numero_residencia.Text = Convert.ToString(controller.buscar(id_funcionario).numero_endereco_funcionario);
                txb_bairro_funcionario.Text = controller.buscar(id_funcionario).bairro_funcionario;
                txb_telefone_funcionario.Text = controller.buscar(id_funcionario).telefone_funcionario;
                txb_id_cargo.Text = Convert.ToString(controller.buscar(id_funcionario).fk_id_cargo);

                txb_nome_funcionario.Enabled = true;
                txb_rg_funcionario.Enabled = true;
                txb_cpf_funcionario.Enabled = true;
                cob_genero_funcionario.Enabled = true;
                txb_datanasc_funcionario.Enabled = true;
                txb_dataadmi_funcionario.Enabled = true;
                txb_endereco_funcionario.Enabled = true;
                txb_numero_residencia.Enabled = true;
                txb_bairro_funcionario.Enabled = true;
                txb_telefone_funcionario.Enabled = true;
                txb_id_cargo.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_funcionario.Text = "";
            txb_nome_funcionario.Text = "";
            txb_rg_funcionario.Text = "";
            txb_cpf_funcionario.Text = "";
            cob_genero_funcionario.Text = "";
            txb_datanasc_funcionario.Text = "";
            txb_dataadmi_funcionario.Text = "";
            txb_endereco_funcionario.Text = "";
            txb_numero_residencia.Text = "";
            txb_bairro_funcionario.Text = "";
            txb_telefone_funcionario.Text = "";
            txb_id_cargo.Text = "";
        }

        /*private void button8_Click(object sender, EventArgs e)
        {

        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Funcionario ORDER BY id_funcionario";
            NpgsqlDataReader dr = con.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_id_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buscar_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txb_telefone_funcionario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_bairro_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cob_genero_funcionario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txb_numero_residencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txb_dataadmi_funcionario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txb_endereco_funcionario_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txb_datanasc_funcionario_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_cpf_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_rg_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txb_nome_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id_funcionario = Int32.Parse(buscar_funcionario.Text);

            FuncionarioController controller = new FuncionarioController();

            var teste = controller.buscar(id_funcionario).nome_funcionario;

            if (teste == null)
            {
                MessageBox.Show("Funcionário não encontrado!");
            }
            else
            {
                MessageBox.Show("Funcionário encontrado com sucesso!");
                txb_id_funcionario.Text = Convert.ToString(controller.buscar(id_funcionario).id_funcionario);
                txb_nome_funcionario.Text = controller.buscar(id_funcionario).nome_funcionario;
                txb_rg_funcionario.Text = controller.buscar(id_funcionario).rg_funcionario;
                txb_cpf_funcionario.Text = controller.buscar(id_funcionario).cpf_funcionario;
                cob_genero_funcionario.Text = controller.buscar(id_funcionario).genero_funcionario;
                txb_datanasc_funcionario.Text = controller.buscar(id_funcionario).dataNasc_funcionario;
                txb_dataadmi_funcionario.Text = controller.buscar(id_funcionario).dataAdmissao_funcionario;
                txb_endereco_funcionario.Text = controller.buscar(id_funcionario).endereco_funcionario;
                txb_numero_residencia.Text = Convert.ToString(controller.buscar(id_funcionario).numero_endereco_funcionario);
                txb_bairro_funcionario.Text = controller.buscar(id_funcionario).bairro_funcionario;
                txb_telefone_funcionario.Text = controller.buscar(id_funcionario).telefone_funcionario;
                txb_id_cargo.Text = Convert.ToString(controller.buscar(id_funcionario).fk_id_cargo);

                txb_nome_funcionario.Enabled = true;
                txb_rg_funcionario.Enabled = true;
                txb_cpf_funcionario.Enabled = true;
                cob_genero_funcionario.Enabled = true;
                txb_datanasc_funcionario.Enabled = true;
                txb_dataadmi_funcionario.Enabled = true;
                txb_endereco_funcionario.Enabled = true;
                txb_numero_residencia.Enabled = true;
                txb_bairro_funcionario.Enabled = true;
                txb_telefone_funcionario.Enabled = true;
                txb_id_cargo.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchCargo ListarCargo = new SearchCargo();
            ListarCargo.ShowDialog();
        }
    }
}
