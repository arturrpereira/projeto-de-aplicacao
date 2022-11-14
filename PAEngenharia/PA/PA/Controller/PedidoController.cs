using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class PedidoController
    {
        public void GetLastId()
        {
            Pedido model = new Pedido();

            model.GetLastId();

            
        }
        /*public Servico buscar(int id_servico)
        {
            Servico model = new Servico();
            model.id_servico = id_servico;

            if (id_servico != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }

            return model;
        }*/
        public void save(int id_pedido, string data_pedido, string forma_pagamento, int fk_id_cliente)
        {
            Pedido model = new Pedido();

            model.id_pedido = id_pedido;
            model.data_pedido = data_pedido;
            model.forma_pagamento = forma_pagamento;
            model.fk_id_cliente = fk_id_cliente;

            model.save();
        }

        public void delete(int id_cliente)
        {
            Cliente model = new Cliente();

            model.delete(id_cliente);


        }
    }
}
