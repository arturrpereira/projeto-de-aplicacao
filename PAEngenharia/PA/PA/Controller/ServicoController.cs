using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class ServicoController
    {
        public Servico buscar(int id_servico)
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
        } 
        public void save(int id_servico, string desc_servico, double valor_servico)
        {
            Servico model = new Servico();

            model.id_servico = id_servico;
            model.desc_servico = desc_servico;
            model.valor_servico = valor_servico;
            
            model.save();
        }

        public void delete(int id_servico)
        {
            Servico model = new Servico();

            model.delete(id_servico);


        }

        public int verifyUser(string login_usuario, string senha_usuario)
        {
            Usuario model = new Usuario();

            model.login_usuario = login_usuario;
            model.senha_usuario = senha_usuario;

            model.verifyUser();

            return model.verifyUser();
        }
    }
}
