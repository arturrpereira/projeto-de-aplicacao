using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class FornecedorController
    {
        public Fornecedor buscar(int id_fornecedor)
        {
            Fornecedor model = new Fornecedor();
            model.id_fornecedor = id_fornecedor;

            if (id_fornecedor != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }

            return model;
        }
        public void save(string nomefantasia, string razaosocial, string cnpjfornecedor, string inscestadual, string tipocontribuinte, string email_fornecedor, string responsavel_fornecedor, string contato_responsavel, string telefone_fornecedor, string endereco_fornecedor)
        {
            Fornecedor model = new Fornecedor();

            model.nomeFantasia = nomefantasia;
            model.razaoSocial = razaosocial;
            model.CNPJFornecedor = cnpjfornecedor;
            model.inscEstadual = inscestadual;
            model.tipoContribuinte = tipocontribuinte;
            model.email_fornecedor = email_fornecedor;
            model.responsavel_fornecedor = responsavel_fornecedor;
            model.contato_responsavel = contato_responsavel;
            model.telefone_fornecedor = telefone_fornecedor;
            model.endereco_fornecedor = endereco_fornecedor;

            model.save();
        }

        public void delete(int id_fornecedor)
        {
            Fornecedor model = new Fornecedor();

            model.delete(id_fornecedor);


        }
    }
}
