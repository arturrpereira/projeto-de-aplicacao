using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Cliente
    {
        public int id_cliente;
        public string nome_cliente;
        public string rg_cliente;
        public string email_cliente;
        public string cpf_cliente;
        public string telefone_cliente;
        public string dataNasc_cliente;
        public string endereco_cliente;
        public int numero_endereco_cliente;
        public string bairro_cliente;
        public int fk_id_usuario;

        public void save()
        {
            ClienteDAO dao = new ClienteDAO();

            if (this.id_cliente == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Cliente getById(Cliente model)
        {
            ClienteDAO dao = new ClienteDAO();

            dao.selectById(this);

            model = dao.selectById(this);

            return model;

        }


        public void delete(int id_cliente)
        {
            ClienteDAO dao = new ClienteDAO();

            dao.delete(id_cliente);
        }


    }
}
