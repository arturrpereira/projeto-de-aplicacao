using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;


namespace PA.Controller
{
    public class EstoqueController
    {
        public Estoque buscar(int id_estoque)
        {
            Estoque model = new Estoque();
            model.id_estoque = id_estoque;

            if (id_estoque != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }

            return model;
        }
        public void save(int id_estoque, string desc_estoque)
        {
            Estoque model = new Estoque();

            model.id_estoque = id_estoque;
            model.desc_estoque = desc_estoque;
            
            model.save();
        }

        public void delete(int id_estoque)
        {
            Estoque model = new Estoque();

            model.delete(id_estoque);
        }
    }
}
