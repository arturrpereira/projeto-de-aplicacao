using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class CargoController
    {
        public Cargo buscar(int id_cargo)
        {
            Cargo model = new Cargo();
            model.id_cargo = id_cargo;

            if (id_cargo != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }
            return model;
        }
        public void save(int id_cargo, string desc_cargo, double salario_cargo, int nivel_cargo)
        {
            Cargo model = new Cargo();

            model.id_cargo = id_cargo;
            model.desc_cargo = desc_cargo;
            model.salario_cargo = salario_cargo;
            model.nivel_cargo = nivel_cargo;
    
            model.save();
        }

        public void delete(int id_cargo)
        {
            Cargo model = new Cargo();

            model.delete(id_cargo);


        }
    }
}
