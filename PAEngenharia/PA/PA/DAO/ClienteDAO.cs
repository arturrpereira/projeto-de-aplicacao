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
    public class ClienteDAO
    {
        public void insert(Cliente model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Cliente (nome_cliente,rg_cliente,email_cliente,cpf_cliente,telefone_cliente,datanasc_cliente,endereco_cliente,numero_endereco_cliente,bairro_cliente,fk_id_usuario) " +
                                               "VALUES (@nome_cliente,@rg_cliente,@email_cliente,@cpf_cliente,@telefone_cliente,@datanasc_cliente,@endereco_cliente,@numero_endereco_cliente,@bairro_cliente,@fk_id_usuario)";

            command.Parameters.AddWithValue("@nome_cliente", model.nome_cliente);
            command.Parameters.AddWithValue("@rg_cliente", model.rg_cliente);
            command.Parameters.AddWithValue("@email_cliente", model.email_cliente);
            command.Parameters.AddWithValue("@cpf_cliente", model.cpf_cliente);
            command.Parameters.AddWithValue("@telefone_cliente", model.telefone_cliente);
            command.Parameters.AddWithValue("@datanasc_cliente", model.dataNasc_cliente);
            command.Parameters.AddWithValue("@endereco_cliente", model.endereco_cliente);
            command.Parameters.AddWithValue("@numero_endereco_cliente", model.numero_endereco_cliente);
            command.Parameters.AddWithValue("@bairro_cliente", model.bairro_cliente);
            command.Parameters.AddWithValue("@fk_id_usuario", Global.id_usuario);

            ConnectionDB.CRUD(command);
        }

        public void update(Cliente model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Cliente SET nome_cliente=@nome_cliente, rg_cliente=@rg_cliente, email_cliente=@email_cliente, cpf_cliente=@cpf_cliente, telefone_cliente=@telefone_cliente, datanasc_cliente=@datanasc_cliente, endereco_cliente=@endereco_cliente, numero_endereco_cliente=@numero_endereco_cliente, bairro_cliente=@bairro_cliente, fk_id_usuario=@fk_id_usuario " +
                                                 "WHERE id_cliente=@id_cliente";

            command.Parameters.AddWithValue("@nome_cliente", model.nome_cliente);
            command.Parameters.AddWithValue("@rg_cliente", model.rg_cliente);
            command.Parameters.AddWithValue("@email_cliente", model.email_cliente);
            command.Parameters.AddWithValue("@cpf_cliente", model.cpf_cliente);
            command.Parameters.AddWithValue("@telefone_cliente", model.telefone_cliente);
            command.Parameters.AddWithValue("@datanasc_cliente", model.dataNasc_cliente);
            command.Parameters.AddWithValue("@endereco_cliente", model.endereco_cliente);
            command.Parameters.AddWithValue("@numero_endereco_cliente", model.numero_endereco_cliente);
            command.Parameters.AddWithValue("@bairro_cliente", model.bairro_cliente);
            command.Parameters.AddWithValue("@fk_id_usuario", Global.id_usuario);

            command.Parameters.AddWithValue("@id_cliente", model.id_cliente);

            ConnectionDB.CRUD(command);
        }
        public NpgsqlDataReader select(Cliente model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Cliente ORDER BY id_cliente";

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            return dr;
        }

        public Cliente selectById(Cliente model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Cliente WHERE id_cliente=@id_cliente";

            command.Parameters.AddWithValue("@id_cliente", model.id_cliente);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_cliente = (int)dr["id_cliente"];
                model.nome_cliente = (string)dr["nome_cliente"];
                model.rg_cliente = (string)dr["rg_cliente"];
                model.email_cliente = (string)dr["email_cliente"];
                model.cpf_cliente = (string)dr["cpf_cliente"];
                model.telefone_cliente = (string)dr["telefone_cliente"];
                model.dataNasc_cliente = (string)dr["datanasc_cliente"];
                model.endereco_cliente = (string)dr["endereco_cliente"];
                model.numero_endereco_cliente = (int)dr["numero_endereco_cliente"];
                model.bairro_cliente = (string)dr["bairro_cliente"];
                model.fk_id_usuario = (int)dr["fk_id_usuario"]; 
            }

            return model;


        }
        public void delete(int id_cliente)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Cliente WHERE id_cliente=@id_cliente";

            command.Parameters.AddWithValue("@id_cliente", id_cliente);

            ConnectionDB.CRUD(command);
        }
    }
}
