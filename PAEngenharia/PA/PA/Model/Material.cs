using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Material
    {
        public int id_material;
        public string desc_material;
        public double preco_material;
        public double qtd_minima;
        public double qtd_maxima;

        public List<Fornecedor> fornecedores = new List<Fornecedor>();

        public Material()
        {
            this.fornecedores = null;
        }
        public void save()
        {
            MaterialDAO dao = new MaterialDAO();

            if (this.id_material == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Material getById(Material model)
        {
            MaterialDAO dao = new MaterialDAO();

            model = dao.selectById(this);

            return model;

        }

        public void delete(int id_material)
        {
            MaterialDAO dao = new MaterialDAO();

            dao.delete(id_material);
        }

    }
}
