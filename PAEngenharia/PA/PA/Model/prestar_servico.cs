using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class prestar_servico
    {
        public string data_execucao;
        public int fk_id_servico;
        public int fk_id_pet;
        public int fk_id_funcionario;
        public int fk_id_pedido;
        public string status_servico;

        public prestar_servico(int fk_id_servico, int fk_id_pet, int fk_id_funcionario, int fk_id_pedido, string data_execucao)
        {
            this.data_execucao = data_execucao;
            this.fk_id_servico = fk_id_servico;
            this.fk_id_pet = fk_id_pet;
            this.fk_id_funcionario = fk_id_funcionario;
            this.fk_id_pedido = fk_id_pedido;
            this.status_servico = "Aberto";
        }

        public void save()
        {
            prestar_servicoDAO dao = new prestar_servicoDAO();

            dao.insert(this);

        }
    }
}
