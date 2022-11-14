using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PA;
using PA.Model;
using PA.Controller;


namespace PA.View
{
    public partial class ListaPedidosView : Form
    {
        public static class Global2
        {
            public static List<prestar_servico> servicos = new List<prestar_servico>();
            //public static Pedido pedido = new Pedido();
        }



        public ListaPedidosView()
        {
            InitializeComponent();
        }

        private void ListaPedidosView_Load(object sender, EventArgs e)
        {
            PedidoController pedidoController = new PedidoController();
            pedidoController.GetLastId();

            txb_id_pedido.Text = Convert.ToString(Global.ultimo_pedido+1);
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SearchCliente ListarCliente = new SearchCliente();
            ListarCliente.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchServico ListarServico = new SearchServico();
            ListarServico.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPET ListarPET = new SearchPET();
            ListarPET.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var id_servico = Int32.Parse(txb_cod_servico.Text);
            var id_pet = Int32.Parse(txb_cod_pet.Text);
            var id_funcionario = Int32.Parse(txb_id_funcionario.Text);
            var id_pedido = Int32.Parse(txb_id_pedido.Text);
            var data_execucao = txb_data_execucao.Text;

            var prestar_servico = new prestar_servico(id_servico, id_pet, id_funcionario, id_pedido, data_execucao);

            Global2.servicos.Add(prestar_servico);

            ServicoController servicoController = new ServicoController();
            servicoController.buscar(id_servico);

            PetController PetController = new PetController();
            PetController.buscar(id_pet);

            FuncionarioController funcionarioController = new FuncionarioController();
            funcionarioController.buscar(id_funcionario);

            listar_servicos.Items.Add("Código do Pet: " + id_pet + ", Nome do Pet: " + PetController.buscar(id_pet).nome_pet + ", Código do Serviço: " + id_servico + ", Descrição do serviço: " + servicoController.buscar(id_servico).desc_servico +  ", Código do funcionario: " + id_funcionario + ", Nome do funcionário: " + funcionarioController.buscar(id_funcionario).nome_funcionario);    
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listar_servicos.Items.Remove(listar_servicos.SelectedItems);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listar_servicos.Items.Clear();
        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            var id_pedido = Int32.Parse(txb_id_pedido.Text);
            var data_pedido = txb_data_pedido.Text;
            var forma_pagamento = cbm_formapagamento.Text;
            var fk_id_cliente = Int32.Parse(txb_cod_cliente.Text);

            PedidoController controller = new PedidoController();

            try
            {
                controller.save(id_pedido, data_pedido, forma_pagamento, fk_id_cliente);
                MessageBox.Show("Pedido programado com sucesso!");
                txb_id_pedido.Text = Convert.ToString(id_pedido + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
                

            foreach(prestar_servico servico in Global2.servicos)
            {
                try
                {
                    servico.save();
                    MessageBox.Show("Serviço programado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex);
                }
                    
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            SearchFuncionario ListarFuncionario = new SearchFuncionario();
            ListarFuncionario.ShowDialog();
        }
    }
}
