using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.DAO;

namespace PA.Model
{
    public class Pet
    {
        public int id_pet;
        public string nome_pet;
        public int idade_pet;
        public string raca_pet;
        public string porte_pet;
        public string cor_pet;
        public int fk_id_cliente;

        public void save()
        {
            PetDAO dao = new PetDAO();

            if (this.id_pet == 0)
            {
                dao.insert(this);
            }
            else
            {

                dao.update(this);
            }

        }

        public Pet getById(Pet model)
        {
            PetDAO dao = new PetDAO();

            model = dao.selectById(this);

            return model;

        }

        public void select()
        {
            FuncionarioDAO dao = new FuncionarioDAO();

           

        }

        public void delete(int id_pet)
        {
            PetDAO dao = new PetDAO();

            dao.delete(id_pet);
        }
    }
}
