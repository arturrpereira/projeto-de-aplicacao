using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class ClienteController
    {
        public Cliente buscar(int id_cliente)
        {
            Cliente model = new Cliente();
            model.id_cliente = id_cliente;

            if (id_cliente != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }
            return model;
        }

        public void save(int id_cliente, string nome_cliente, string rg_cliente, string cpf_cliente, string datanasc_cliente, string telefone_cliente, string email_cliente, string endereco_cliente, int numero_endereco_cliente, string bairro_cliente)
        {
            Cliente model = new Cliente();

            model.id_cliente = id_cliente;
            model.nome_cliente = nome_cliente;
            model.rg_cliente = rg_cliente;
            model.cpf_cliente = cpf_cliente;
            model.dataNasc_cliente = datanasc_cliente;
            model.telefone_cliente = telefone_cliente;
            model.email_cliente = email_cliente;
            model.endereco_cliente = endereco_cliente;
            model.numero_endereco_cliente = numero_endereco_cliente;
            model.bairro_cliente = bairro_cliente;

            model.save();
        }

        public void delete(int id_funcionario)
        {
            Funcionario model = new Funcionario();

            model.delete(id_funcionario);
        }
    }
}
