using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Cargo
    {
        public int id_cargo;
        public string desc_cargo;
        public double salario_cargo;
        public int nivel_cargo;

        public void save()
        {
            CargoDAO dao = new CargoDAO();

            if (this.id_cargo == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }
        }

        public Cargo getById(Cargo model)
        {
            CargoDAO dao = new CargoDAO();

            dao.selectById(this);

            model = dao.selectById(this);

            return model;

        }
        public void delete(int id_cargo)
        {
            CargoDAO dao = new CargoDAO();

            dao.delete(id_cargo);
        }
    }
}
