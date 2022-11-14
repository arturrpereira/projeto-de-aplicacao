using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class MaterialController
    {
        public Material buscar(int id_material)
        {
            Material model = new Material();
            model.id_material = id_material;

            if (id_material != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }

            return model;
        }
        public void save(int id_material, string desc_material, double preco_material, double qtd_minimo, double qtd_maximo)
        {
            Material model = new Material();

            model.id_material = id_material;
            model.desc_material = desc_material;
            model.preco_material = preco_material;
            model.qtd_minima = qtd_minimo;
            model.qtd_maxima = qtd_maximo;

            model.save();
        }

        public void delete(int id_material)
        {
            Material model = new Material();

            model.delete(id_material);
        }
    }
}
