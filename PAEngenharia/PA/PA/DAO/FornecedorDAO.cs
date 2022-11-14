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
    public class FornecedorDAO
    {
        public void insert(Fornecedor model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Fornecedor (nomefantasia, razaosocial, cnpjfornecedor, inscestadual, tipocontribuinte, email_fornecedor, responsavel_fornecedor, contato_responsavel, telefone_fornecedor, endereco_fornecedor) " +
                                             "VALUES (@nomefantasia, @razaosocial, @cnpjfornecedor, @inscestadual, @tipocontribuinte, @email_fornecedor, @responsavel_fornecedor, @contato_responsavel, @telefone_fornecedor, @endereco_fornecedor)";

            command.Parameters.AddWithValue("@nomefantasia", model.nomeFantasia);
            command.Parameters.AddWithValue("@razaosocial", model.razaoSocial);
            command.Parameters.AddWithValue("@cnpjfornecedor", model.CNPJFornecedor);
            command.Parameters.AddWithValue("@inscestadual", model.inscEstadual);
            command.Parameters.AddWithValue("@tipocontribuinte", model.tipoContribuinte);
            command.Parameters.AddWithValue("@email_fornecedor", model.email_fornecedor);
            command.Parameters.AddWithValue("@responsavel_fornecedor", model.responsavel_fornecedor);
            command.Parameters.AddWithValue("@contato_responsavel", model.contato_responsavel);
            command.Parameters.AddWithValue("@telefone_fornecedor", model.telefone_fornecedor);
            command.Parameters.AddWithValue("@endereco_fornecedor", model.endereco_fornecedor);

            ConnectionDB.CRUD(command);
        }

        public void update(Fornecedor model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Fornecedor SET nomefantasia=@nomefantasia, razaosocial=@razaosocial, cnpjfornecedor=@cnpjfornecedor, inscestadual=@inscestadual, tipocontribuinte=@tipocontribuinte, email_fornecedor=@email_fornecedor, responsavel_fornecedor=@responsavel_fornecedor, contato_responsavel=@contato_responsavel, telefone_fornecedor=@telefone_fornecedor, endereco_fornecedor=@endereco_fornecedor " +
                                                    "WHERE id_fornecedor=@id_fornecedor";

            command.Parameters.AddWithValue("@nomefantasia", model.nomeFantasia);
            command.Parameters.AddWithValue("@razaosocial", model.razaoSocial);
            command.Parameters.AddWithValue("@cnpjfornecedor", model.CNPJFornecedor);
            command.Parameters.AddWithValue("@inscestadual", model.inscEstadual);
            command.Parameters.AddWithValue("@tipocontribuinte", model.tipoContribuinte);
            command.Parameters.AddWithValue("@email_fornecedor", model.email_fornecedor);
            command.Parameters.AddWithValue("@responsavel_fornecedor", model.responsavel_fornecedor);
            command.Parameters.AddWithValue("@contato_responsavel", model.contato_responsavel);
            command.Parameters.AddWithValue("@telefone_fornecedor", model.telefone_fornecedor);
            command.Parameters.AddWithValue("@endereco_fornecedor", model.endereco_fornecedor);

            command.Parameters.AddWithValue("@id_fornecedor", model.id_fornecedor);

            ConnectionDB.CRUD(command);
        }

        public Fornecedor selectById(Fornecedor model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Fornecedor WHERE id_fornecedor=@id_fornecedor";

            command.Parameters.AddWithValue("@id_fornecedor", model.id_fornecedor);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if (dr.HasRows)
            {
                dr.Read();
                model.id_fornecedor = (int)dr["id_fornecedor"];
                model.nomeFantasia = (string)dr["nomefantasia"];
                model.razaoSocial = (string)dr["razaosocial"];
                model.CNPJFornecedor = (string)dr["cnpjfornecedor"];
                model.inscEstadual = (string)dr["inscestadual"];
                model.tipoContribuinte = (string)dr["tipocontribuinte"];
                model.email_fornecedor = (string)dr["email_fornecedor"];
                model.responsavel_fornecedor = (string)dr["responsavel_fornecedor"];
                model.contato_responsavel = (string)dr["contato_responsavel"];
                model.telefone_fornecedor = (string)dr["telefone_fornecedor"];
                model.endereco_fornecedor = (string)dr["endereco_fornecedor"];
            }

            return model;
        }

        public void delete(int id_fornecedor)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Fornecedor WHERE id_fornecedor=@id_fornecedor";

            command.Parameters.AddWithValue("@id_fornecedor", id_fornecedor);

            ConnectionDB.CRUD(command);
        }
    }
}
