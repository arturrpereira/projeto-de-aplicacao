using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA.db;
using Npgsql;
using PA.Model;

namespace PA.DAO
{
    public class EstoqueDAO
    {
        public void insert(Estoque model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Estoque (desc_estoque) " +
                                             "VALUES (@desc_estoque)";

            command.Parameters.AddWithValue("@desc_estoque", model.desc_estoque);
           
            ConnectionDB.CRUD(command);
        }

        public void update(Estoque model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Estoque SET desc_estoque=@desc_estoque " +
                                                 "WHERE id_estoque=@id_estoque";

            command.Parameters.AddWithValue("@desc_estoque", model.desc_estoque);
            command.Parameters.AddWithValue("@id_estoque", model.id_estoque);

            ConnectionDB.CRUD(command);
        }

        public Estoque selectById(Estoque model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Estoque WHERE id_estoque=@id_estoque";

            command.Parameters.AddWithValue("@id_estoque", model.id_estoque);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_estoque = (int)dr["id_estoque"];
                model.desc_estoque = (string)dr["desc_estoque"];
            }

            return model;
        }

        public void delete(int id_estoque)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Estoque WHERE id_estoque=@id_estoque";

            command.Parameters.AddWithValue("@id_estoque", id_estoque);

            ConnectionDB.CRUD(command);
        }
    }
}
