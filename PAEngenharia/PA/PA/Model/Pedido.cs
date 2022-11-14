using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;
using PA.DAO;

namespace PA.Model
{
    public class Pedido
    {
        public int id_pedido;
        public string data_pedido;
        public string status_pedido;
        public string forma_pagamento;
        public int fk_id_cliente;

        public List<prestar_servico> prestar_servico = new List<prestar_servico>();

        public Pedido()
        {
            this.status_pedido = "Aberto";
        }
        
        public void save()
        {
            PedidoDAO dao = new PedidoDAO();
            dao.insert(this);

            if (this.id_pedido == 0)
            {
                
            }
            else
            {

              
            }
        }
        public void GetLastId()
        {
            PedidoDAO dao = new PedidoDAO();

            dao.GetLastId(this);
        }
    }
}
