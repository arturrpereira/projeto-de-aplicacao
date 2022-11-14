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
    public class MaterialDAO
    {
        public void insert(Material model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Material (desc_material, preco_material, qtd_minimo, qtd_maximo) " +
                                             "VALUES (@desc_material, @preco_material, @qtd_minimo, @qtd_maximo)";

            command.Parameters.AddWithValue("@desc_material", model.desc_material);
            command.Parameters.AddWithValue("@preco_material", model.preco_material);
            command.Parameters.AddWithValue("@qtd_minimo", model.qtd_minima);
            command.Parameters.AddWithValue("@qtd_maximo", model.qtd_maxima);
           
            ConnectionDB.CRUD(command);
        }

        public void update(Material model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Material SET desc_material=@desc_material, preco_material=@preco_material, qtd_minimo=@qtd_minimo, qtd_maximo=@qtd_maximo " +
                                                    "WHERE id_material=@id_material";

            command.Parameters.AddWithValue("@desc_material", model.desc_material);
            command.Parameters.AddWithValue("@preco_material", model.preco_material);
            command.Parameters.AddWithValue("@qtd_minimo", model.qtd_minima);
            command.Parameters.AddWithValue("@qtd_maximo", model.qtd_maxima);

            command.Parameters.AddWithValue("@id_material", model.id_material);

            ConnectionDB.CRUD(command);
        }

        public Material selectById(Material model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Material WHERE id_material=@id_material";

            command.Parameters.AddWithValue("@id_material", model.id_material);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_material = (int)dr["id_material"];
                model.desc_material = (string)dr["desc_material"];
                model.preco_material = (double)dr["preco_material"];
                model.qtd_minima = (double)dr["qtd_minimo"];
                model.qtd_maxima = (double)dr["qtd_maximo"];
                
            }

            return model;
        }

        public void delete(int id_material)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Material WHERE id_material=@id_material";

            command.Parameters.AddWithValue("@id_material", id_material);

            ConnectionDB.CRUD(command);
        }
    }
}
