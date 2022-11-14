using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Fornecedor
    {
        public int id_fornecedor;
        public string nomeFantasia;
        public string razaoSocial;
        public string CNPJFornecedor;
        public string inscEstadual;
        public string tipoContribuinte;
        public string email_fornecedor;
        public string responsavel_fornecedor;
        public string contato_responsavel;
        public string telefone_fornecedor;
        public string endereco_fornecedor;

        public List<Material> materiais = new List<Material>();

        public Fornecedor()
        {
            this.materiais = null;
        }

        public void save()
        {
            FornecedorDAO dao = new FornecedorDAO();

            if (this.id_fornecedor == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Fornecedor getById(Fornecedor model)
        {
            FornecedorDAO dao = new FornecedorDAO();

            model = dao.selectById(this);

            return model;

        }
        public void delete(int id_fornecedor)
        {
            FornecedorDAO dao = new FornecedorDAO();

            dao.delete(id_fornecedor);
        }
    }
}
