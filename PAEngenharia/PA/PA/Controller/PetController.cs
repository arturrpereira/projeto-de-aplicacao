using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;

namespace PA.Controller
{
    public class PetController
    {
        public Pet buscar(int id_pet)
        {
            Pet model = new Pet();
            model.id_pet = id_pet;

            if (id_pet != 0)
            {
                model = model.getById(model);
            }
            else
            {

            }

            return model;
        }
        public void save(int id_pet, string nome_pet, int idade_pet, string raca_pet, string porte_pet, string cor_pet, int fk_id_cliente)
        {
            Pet model = new Pet();

            model.id_pet = id_pet;
            model.nome_pet = nome_pet;
            model.idade_pet = idade_pet;
            model.raca_pet = raca_pet;
            model.porte_pet = porte_pet;
            model.cor_pet = cor_pet;
            model.fk_id_cliente = fk_id_cliente;

            model.save();
        }

        public void delete(int id_pet)
        {
            Pet model = new Pet();

            model.delete(id_pet);


        }
    }
}
