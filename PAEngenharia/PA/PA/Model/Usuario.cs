using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Usuario
    {
        public int id_usuario;
        public string login_usuario;
        public string senha_usuario;
        public int fk_id_funcionario;

        public void save()
        {
            UsuarioDAO dao = new UsuarioDAO();

            if (this.id_usuario == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Usuario getById(Usuario model)
        {
            UsuarioDAO dao = new UsuarioDAO();

            dao.selectById(this);

            model = dao.selectById(this);

            return model;

        }

        public void select()
        {
            FuncionarioDAO dao = new FuncionarioDAO();

            // dao.(this);

        }

        public void delete(int id_usuario)
        {
            UsuarioDAO dao = new UsuarioDAO();

            dao.delete(id_usuario);
        }

        public int verifyUser()
        {
            UsuarioDAO dao = new UsuarioDAO();

            return dao.verifyUser(this);
        }

       
    }
}
