using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Estoque
    {
        public int id_estoque;
        public string desc_estoque;

        public List<Material> materiais = new List<Material>();

        public void save()
        {
            EstoqueDAO dao = new EstoqueDAO();

            if (this.id_estoque == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Estoque getById(Estoque model)
        {
            EstoqueDAO dao = new EstoqueDAO();
            
            model = dao.selectById(this);

            return model;

        }


        public void delete(int id_estoque)
        {
            EstoqueDAO dao = new EstoqueDAO();

            dao.delete(id_estoque);
        }

        

    }
}
