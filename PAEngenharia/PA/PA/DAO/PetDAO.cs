using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using PA.db;
using PA.Model;

namespace PA.DAO
{
    public class PetDAO
    {
        public void insert(Pet model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Pet (nome_pet, idade_pet, raca_pet, porte_pet, cor_pet, fk_id_cliente) " +
                                         "VALUES (@nome_pet, @idade_pet, @raca_pet, @porte_pet, @cor_pet, @fk_id_cliente)";

            command.Parameters.AddWithValue("@nome_pet", model.nome_pet);
            command.Parameters.AddWithValue("@idade_pet", model.idade_pet);
            command.Parameters.AddWithValue("@raca_pet", model.raca_pet);
            command.Parameters.AddWithValue("@porte_pet", model.porte_pet);
            command.Parameters.AddWithValue("@cor_pet", model.cor_pet);
            command.Parameters.AddWithValue("@fk_id_cliente", model.fk_id_cliente);
            
            ConnectionDB.CRUD(command);
        }

        public void update(Pet model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Pet SET nome_pet=@nome_pet, idade_pet=@idade_pet, raca_pet=@raca_pet, porte_pet=@porte_pet, cor_pet=@cor_pet, fk_id_cliente=@fk_id_cliente " +
                                                 "WHERE id_pet=@id_pet";

            command.Parameters.AddWithValue("@nome_pet", model.nome_pet);
            command.Parameters.AddWithValue("@idade_pet", model.idade_pet);
            command.Parameters.AddWithValue("@raca_pet", model.raca_pet);
            command.Parameters.AddWithValue("@porte_pet", model.porte_pet);
            command.Parameters.AddWithValue("@cor_pet", model.cor_pet);
            command.Parameters.AddWithValue("@fk_id_cliente", model.fk_id_cliente);
            command.Parameters.AddWithValue("@id_pet", model.id_pet);

            ConnectionDB.CRUD(command);
        }

        public Pet selectById(Pet model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Pet WHERE id_pet=@id_pet";

            command.Parameters.AddWithValue("@id_pet", model.id_pet);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_pet = (int)dr["id_pet"];
                model.nome_pet = (string)dr["nome_pet"];
                model.idade_pet = (int)dr["idade_pet"];
                model.raca_pet = (string)dr["raca_pet"];
                model.porte_pet = (string)dr["porte_pet"];
                model.cor_pet = (string)dr["cor_pet"];
                model.fk_id_cliente = (int)dr["fk_id_cliente"];
            }

            return model;
        }

        public void delete(int id_pet)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Pet WHERE id_pet=@id_pet";

            command.Parameters.AddWithValue("@id_pet", id_pet);

            ConnectionDB.CRUD(command);
        }
    }
}
