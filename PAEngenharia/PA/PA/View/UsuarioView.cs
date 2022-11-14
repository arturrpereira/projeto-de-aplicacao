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
    public partial class UsuarioView : Form
    {
        public UsuarioView()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
           
            txb_login_usuario.Enabled = true;
            txb_senha_usuario.Enabled = true;
            txb_id_funcionario.Enabled = true;
        }

        private void UsuarioView_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchFuncionario ListarFuncionario = new SearchFuncionario();
            ListarFuncionario.ShowDialog();
        }

        private void enviar_funcionario_Click(object sender, EventArgs e)
        {
            int id_usuario;

            if (txb_id_usuario.Text != "")
            {
                id_usuario = Int32.Parse(txb_id_usuario.Text);
            }
            else
            {
                id_usuario = 0;
            }
            var login_usuario = txb_login_usuario.Text;
            var senha_usuario = txb_senha_usuario.Text;
            var fk_id_funcionario = Int32.Parse(txb_id_funcionario.Text);

            UsuarioController controller = new UsuarioController();

            try
            {
                controller.save(id_usuario, login_usuario, senha_usuario, fk_id_funcionario);
                MessageBox.Show("Usuário Cadastrado com sucesso!");
                txb_login_usuario.Text = "";
                txb_senha_usuario.Text = "";
                txb_id_funcionario.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id_usuario;

            if (txb_id_usuario.Text != null)
            {
                id_usuario = Int32.Parse(txb_id_usuario.Text);
            }
            else
            {
                id_usuario = 0;
            }
            var login_usuario = txb_login_usuario.Text;
            var senha_usuario = txb_senha_usuario.Text;
            var fk_id_funcionario = Int32.Parse(txb_id_funcionario.Text);

            UsuarioController controller = new UsuarioController();

            try
            {
                controller.save(id_usuario, login_usuario, senha_usuario, fk_id_funcionario);
                MessageBox.Show("Usuario atualizado com sucesso!");
                txb_id_usuario.Text = "";
                txb_login_usuario.Text = "";
                txb_senha_usuario.Text = "";
                txb_id_funcionario.Text = "";
                buscar_funcionario.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var id_usuario = Int32.Parse(buscar_funcionario.Text);

            UsuarioController controller = new UsuarioController();

            var teste = controller.buscar(id_usuario).login_usuario;

            if (teste == null)
            {
                MessageBox.Show("Usuario não encontrado!");
            }
            else
            {
                MessageBox.Show("Usuário encontrado com sucesso!");
                txb_id_usuario.Text = Convert.ToString(controller.buscar(id_usuario).id_usuario);
                txb_login_usuario.Text = controller.buscar(id_usuario).login_usuario;
                txb_senha_usuario.Text = controller.buscar(id_usuario).senha_usuario;
                txb_id_funcionario.Text = Convert.ToString(controller.buscar(id_usuario).fk_id_funcionario);

                txb_login_usuario.Enabled = true;
                txb_senha_usuario.Enabled = true;
                txb_id_funcionario.Enabled = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult OpcaoUser = new DialogResult();
            OpcaoUser = MessageBox.Show("O usuário a seguir será deletado: " + txb_login_usuario.Text, "Atenção", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (OpcaoUser == DialogResult.OK)
            {
                int id_usuario = Int32.Parse(txb_id_usuario.Text);

                UsuarioController controller = new UsuarioController();

                try
                {
                    controller.delete(id_usuario);
                    txb_id_usuario.Text = "";
                    txb_login_usuario.Text = "";
                    txb_senha_usuario.Text = "";
                    txb_id_funcionario.Text = "";
                    

                    MessageBox.Show("Usuário deletado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar usuário: " + ex);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txb_id_usuario.Text = "";
            txb_login_usuario.Text = "";
            txb_senha_usuario.Text = "";
            txb_id_funcionario.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Usuario ORDER BY id_usuario";
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
