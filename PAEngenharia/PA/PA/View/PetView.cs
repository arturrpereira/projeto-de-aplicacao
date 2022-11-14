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
using PA.db;
using Npgsql;

namespace PA.View
{
    public partial class PetView : Form
    {
        public PetView()
        {
            InitializeComponent();
        }

        private void PetView_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_nome_pet.Enabled = true;
            txb_idade_pet.Enabled = true;
            txb_raca_pet.Enabled = true;
            cob_porte_pet.Enabled = true;
            txb_cor_pet.Enabled = true;
            txb_id_cliente.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchCliente ListarCliente = new SearchCliente();
            ListarCliente.ShowDialog();
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_pet;

            if (txb_id_pet.Text != "")
            {
                id_pet = Int32.Parse(txb_id_pet.Text);
            }
            else
            {
                id_pet = 0;
            }
            var nome_pet = txb_nome_pet.Text;
            var idade_pet = Int32.Parse(txb_idade_pet.Text);
            var raca_pet = txb_raca_pet.Text;
            var porte_pet = cob_porte_pet.Text;
            var cor_pet = txb_cor_pet.Text;
            var fk_id_cliente = Int32.Parse(txb_id_cliente.Text);



            PetController controller = new PetController();

            try
            {
                controller.save(id_pet, nome_pet, idade_pet, raca_pet, porte_pet, cor_pet, fk_id_cliente);
                MessageBox.Show("Pet Cadastrado com sucesso!");
                txb_nome_pet.Text = "";
                txb_idade_pet.Text = "";
                txb_raca_pet.Text = "";
                cob_porte_pet.Text = "";
                txb_cor_pet.Text = "";
                txb_id_cliente.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_pet;

            if (txb_id_pet.Text != "")
            {
                id_pet = Int32.Parse(txb_id_pet.Text);
            }
            else
            {
                id_pet = 0;
            }
            var nome_pet = txb_nome_pet.Text;
            var idade_pet = Int32.Parse(txb_idade_pet.Text);
            var raca_pet = txb_raca_pet.Text;
            var porte_pet = cob_porte_pet.Text;
            var cor_pet = txb_cor_pet.Text;
            var fk_id_cliente = Int32.Parse(txb_id_cliente.Text);



            PetController controller = new PetController();

            try
            {
                controller.save(id_pet, nome_pet, idade_pet, raca_pet, porte_pet, cor_pet, fk_id_cliente);
                MessageBox.Show("Pet atualizado com sucesso!");
                txb_id_pet.Text = "";
                txb_nome_pet.Text = "";
                txb_idade_pet.Text = "";
                txb_raca_pet.Text = "";
                cob_porte_pet.Text = "";
                txb_cor_pet.Text = "";
                txb_id_cliente.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O pet a seguir será deletado: " + txb_nome_pet.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_pet = Int32.Parse(txb_id_pet.Text);

                PetController controller = new PetController();

                try
                {
                    controller.delete(id_pet);
                    txb_id_pet.Text = "";
                    txb_nome_pet.Text = "";
                    txb_idade_pet.Text = "";
                    txb_raca_pet.Text = "";
                    cob_porte_pet.Text = "";
                    txb_cor_pet.Text = "";
                    txb_id_cliente.Text = "";

                    MessageBox.Show("Pet deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar pet: " + ex);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_pet.Text = "";
            txb_nome_pet.Text = "";
            txb_idade_pet.Text = "";
            txb_raca_pet.Text = "";
            cob_porte_pet.Text = "";
            txb_cor_pet.Text = "";
            txb_id_cliente.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Pet ORDER BY id_pet";
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
            if (buscar_pet.Text == "")
            {
                MessageBox.Show("Favor preencher o campo para efetuar busca!");
            }
            else
            {
                var id_pet = Int32.Parse(buscar_pet.Text);

                PetController controller = new PetController();

                var model = controller.buscar(id_pet);

                if (model.nome_pet == null)
                {
                    MessageBox.Show("Pet não encontrado!");
                }
                else
                {
                    MessageBox.Show("Pet encontrado com sucesso!");
                    txb_id_pet.Text = Convert.ToString(model.id_pet);
                    txb_nome_pet.Text = model.nome_pet;
                    txb_idade_pet.Text = Convert.ToString(model.idade_pet);
                    txb_raca_pet.Text = model.raca_pet;
                    cob_porte_pet.Text = model.porte_pet;
                    txb_cor_pet.Text = model.cor_pet;
                    txb_id_cliente.Text = Convert.ToString(model.fk_id_cliente);
                }
            }
        }
    }
}
