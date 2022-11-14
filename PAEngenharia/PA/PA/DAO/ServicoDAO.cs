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
    public class ServicoDAO
    {
        public void insert(Servico model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Servico (desc_servico, valor_servico) " +
                                               "VALUES (@desc_servico, @valor_servico)";

            command.Parameters.AddWithValue("@desc_servico", model.desc_servico);
            command.Parameters.AddWithValue("@valor_servico", model.valor_servico);
           
            ConnectionDB.CRUD(command);
        }

        public void update(Servico model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Servico SET desc_servico=@desc_servico, valor_servico=@valor_servico " +
                                                 "WHERE id_servico=@id_servico";

            command.Parameters.AddWithValue("@desc_servico", model.desc_servico);
            command.Parameters.AddWithValue("@valor_servico", model.valor_servico);
            command.Parameters.AddWithValue("@id_servico", model.id_servico);

            ConnectionDB.CRUD(command);
        }
        public Servico selectById(Servico model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Servico WHERE id_servico=@id_servico";

            command.Parameters.AddWithValue("@id_servico", model.id_servico);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_servico = (int)dr["id_servico"];
                model.desc_servico = (string)dr["desc_servico"];
                model.valor_servico = (double)dr["valor_servico"];
            }

            return model;
        }

        public void delete(int id_servico)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Servico WHERE id_servico=@id_servico";

            command.Parameters.AddWithValue("@id_servico", id_servico);

            ConnectionDB.CRUD(command);
        }
    }
}
