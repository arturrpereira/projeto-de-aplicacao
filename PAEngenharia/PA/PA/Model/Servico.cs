using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Servico
    {
        public int id_servico;
        public string desc_servico;
        public double valor_servico;

        public List<Funcionario> funcionarios = new List<Funcionario>();

        public Servico()
        {
            this.funcionarios = null;
        }

        public void save()
        {
            ServicoDAO dao = new ServicoDAO();

            if (this.id_servico == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Servico getById(Servico model)
        {
            ServicoDAO dao = new ServicoDAO();

            dao.selectById(this);

            model = dao.selectById(this);

            return model;

        }


        public void delete(int id_servico)
        {
            ServicoDAO dao = new ServicoDAO();

            dao.delete(id_servico);
        }
    }
}
