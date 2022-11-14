using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class UsuarioController
    {
        public Usuario buscar(int id_usuario)
        {
            Usuario model = new Usuario();
            model.id_usuario = id_usuario;

            if (id_usuario != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }

            return model;
        }
        public void save(int id_usuario, string login_usuario, string senha_usuario, int fk_id_funcionario)
        {
            Usuario model = new Usuario();

            model.id_usuario = id_usuario;
            model.login_usuario = login_usuario;
            model.senha_usuario = senha_usuario;
            model.fk_id_funcionario = fk_id_funcionario;

            model.save();
        }

        public void delete(int id_usuario)
        {
            Usuario model = new Usuario();

            model.delete(id_usuario);


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
