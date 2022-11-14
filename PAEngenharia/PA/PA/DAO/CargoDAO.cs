using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.Model;
using Npgsql;
using PA.db;

namespace PA.DAO
{
    public class CargoDAO
    {
        public void insert(Cargo model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Cargo (desc_cargo, salario_cargo, nivel_cargo) " +
                                             "VALUES (@desc_cargo, @salario_cargo, @nivel_cargo)";

            command.Parameters.AddWithValue("@desc_cargo", model.desc_cargo);
            command.Parameters.AddWithValue("@salario_cargo", model.salario_cargo);
            command.Parameters.AddWithValue("@nivel_cargo", model.nivel_cargo);

            ConnectionDB.CRUD(command);
        }

        public void update(Cargo model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Cargo SET desc_cargo=@desc_cargo, salario_cargo=@salario_cargo, nivel_cargo=@nivel_cargo " +
                                                 "WHERE id_cargo=@id_cargo";

            command.Parameters.AddWithValue("@desc_cargo", model.desc_cargo);
            command.Parameters.AddWithValue("@salario_cargo", model.salario_cargo);
            command.Parameters.AddWithValue("@nivel_cargo", model.nivel_cargo);
            command.Parameters.AddWithValue("@id_cargo", model.id_cargo);

            ConnectionDB.CRUD(command);
        }

        public Cargo selectById(Cargo model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Cargo WHERE id_cargo=@id_cargo";

            command.Parameters.AddWithValue("@id_cargo", model.id_cargo);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_cargo= (int)dr["id_cargo"];
                model.desc_cargo = (string)dr["desc_cargo"];
                model.salario_cargo = (double)dr["salario_cargo"];
                model.nivel_cargo = (int)dr["nivel_cargo"];
            
            }

            return model;
        }

        public void delete(int id_cargo)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Cargo WHERE id_cargo=@id_cargo";

            command.Parameters.AddWithValue("@id_cargo", id_cargo);

            ConnectionDB.CRUD(command);
        }
    }
}
