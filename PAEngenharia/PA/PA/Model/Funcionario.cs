using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Funcionario
    {
        public int id_funcionario;
        public string nome_funcionario;
        public string rg_funcionario;
        public string cpf_funcionario;
        public string endereco_funcionario;
        public int numero_endereco_funcionario;
        public string bairro_funcionario;
        public string dataAdmissao_funcionario;
        public string dataNasc_funcionario;
        public string genero_funcionario;
        public string telefone_funcionario;
        public int fk_id_cargo;

        public List<Servico> servicos = new List<Servico>();

        public Funcionario()
        {
            this.servicos = null;
        }

        public void save()
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            if (this.id_funcionario == 0)
            {
                dao.insert(this);
            } 
            else
            {
                
                dao.update(this);
            }

        }

        public Funcionario getById(Funcionario model)
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            dao.selectById(this);

            model = dao.selectById(this);

            return model;
   
        }

        public void delete(int id_funcionario)
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            dao.delete(id_funcionario);
        }
    }
}
