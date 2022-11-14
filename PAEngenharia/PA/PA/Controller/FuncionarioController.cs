using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;
using PA.Model;

namespace PA.Controller
{
    public class FuncionarioController
    {
        public Funcionario buscar(int id_funcionario)
        {
            Funcionario model = new Funcionario();
            model.id_funcionario = id_funcionario;

            if(id_funcionario != 0)
            {
                model = model.getById(model);
            }
            else
            {
                
            }
            return model;
        }

        public void save(int id_funcionario, string nome_funcionario, string rg_funcionario, string cpf_funcionario, string endereco_funcionario, int numero_endereco_funcionario, string bairro_funcionario, string dataAdmissao_funcionario, string dataNasc_funcionario, string genero_funcionario, string telefone_funcionario, int fk_id_cargo)
        {
            Funcionario model = new Funcionario();

            model.id_funcionario = id_funcionario;
            model.nome_funcionario = nome_funcionario;
            model.rg_funcionario = rg_funcionario;
            model.cpf_funcionario = cpf_funcionario;
            model.endereco_funcionario = endereco_funcionario;
            model.numero_endereco_funcionario = numero_endereco_funcionario;
            model.bairro_funcionario = bairro_funcionario;
            model.dataAdmissao_funcionario = dataAdmissao_funcionario;
            model.dataNasc_funcionario = dataNasc_funcionario;
            model.genero_funcionario = genero_funcionario;
            model.telefone_funcionario = telefone_funcionario;
            model.fk_id_cargo = fk_id_cargo;

            model.save();
        }

        public void delete(int id_funcionario)
        {
            Funcionario model = new Funcionario();

            model.delete(id_funcionario);

            
        }
    }
}
