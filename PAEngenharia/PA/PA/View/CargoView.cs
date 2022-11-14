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
    public partial class CargoView : Form
    {
        public CargoView()
        {
            InitializeComponent();
        }

        private void txb_id_funcionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargoView_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txb_dsc_cargo.Enabled = true;
            txb_salario.Enabled = true;
            txb_nivel_cargo.Enabled = true;

        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_cargo;

            if (txb_id_cargo.Text != "")
            {
                id_cargo = Int32.Parse(txb_id_cargo.Text);
            }
            else
            {
                id_cargo = 0;
            }
            var desc_cargo = txb_dsc_cargo.Text;
            var salario_cargo = Convert.ToDouble(txb_salario.Text);
            var nivel_cargo = Int32.Parse(txb_nivel_cargo.Text);


            CargoController controller = new CargoController();

            try
            {
                controller.save(id_cargo, desc_cargo, salario_cargo, nivel_cargo);
                MessageBox.Show("Cargo Cadastrado com sucesso!");
                txb_dsc_cargo.Text = "";
                txb_salario.Text = "";
                txb_nivel_cargo.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_cargo;

            if (txb_id_cargo.Text != null)
            {
                id_cargo = Int32.Parse(txb_id_cargo.Text);
            }
            else
            {
                id_cargo = 0;
            }
            var desc_cargo = txb_dsc_cargo.Text;
            var salario_cargo = Convert.ToDouble(txb_salario.Text);
            var nivel_cargo = Int32.Parse(txb_nivel_cargo.Text);

            CargoController controller = new CargoController();

            try
            {
                controller.save(id_cargo, desc_cargo, salario_cargo, nivel_cargo);
                MessageBox.Show("Cargo atualizado com sucesso!");
                txb_id_cargo.Text = "";
                txb_dsc_cargo.Text = "";
                txb_salario.Text = "";
                txb_nivel_cargo.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var id_cargo = Int32.Parse(buscar_cargo.Text);

            CargoController controller = new CargoController();

            var teste = controller.buscar(id_cargo).desc_cargo;

            if (teste == null)
            {
                MessageBox.Show("Cargo não encontrado!");
            }
            else
            {
                MessageBox.Show("Cargo encontrado com sucesso!");
                txb_id_cargo.Text = Convert.ToString(controller.buscar(id_cargo).id_cargo);
                txb_dsc_cargo.Text = controller.buscar(id_cargo).desc_cargo;
                txb_salario.Text = Convert.ToString(controller.buscar(id_cargo).salario_cargo);
                txb_nivel_cargo.Text = Convert.ToString(controller.buscar(id_cargo).nivel_cargo);


                txb_dsc_cargo.Enabled = true;
                txb_salario.Enabled = true;
                txb_nivel_cargo.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_cargo.Text = "";
            txb_dsc_cargo.Text = "";
            txb_salario.Text = "";
            txb_nivel_cargo.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O cargo a seguir será deletado: " + txb_dsc_cargo.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_cargo = Int32.Parse(txb_id_cargo.Text);
                CargoController controller = new CargoController();
                try
                {
                    controller.delete(id_cargo);
                    txb_id_cargo.Text = "";
                    txb_dsc_cargo.Text = "";
                    txb_salario.Text = "";
                    txb_nivel_cargo.Text = "";
                    MessageBox.Show("Cargo deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar cargo: " + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Cargo ORDER BY id_cargo";
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
