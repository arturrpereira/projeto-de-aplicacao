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
    public class FuncionarioDAO
    {
        public void insert(Funcionario model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO Funcionario (nome_funcionario,rg_funcionario,cpf_funcionario,endereco_funcionario,numero_endereco_funcionario,bairro_funcionario,dataadmissao_funcionario,datanasc_funcionario,genero_funcionario,telefone_funcionario,fk_id_cargo) " +
                                  "VALUES (@nome_funcionario,@rg_funcionario,@cpf_funcionario,@endereco_funcionario,@numero_endereco_funcionario,@bairro_funcionario,@dataadmissao_funcionario,@datanasc_funcionario,@genero_funcionario,@telefone_funcionario,@fk_id_cargo)";

            command.Parameters.AddWithValue("@nome_funcionario", model.nome_funcionario);
            command.Parameters.AddWithValue("@rg_funcionario", model.rg_funcionario);
            command.Parameters.AddWithValue("@cpf_funcionario", model.cpf_funcionario);
            command.Parameters.AddWithValue("@endereco_funcionario", model.endereco_funcionario);
            command.Parameters.AddWithValue("@numero_endereco_funcionario", model.numero_endereco_funcionario);
            command.Parameters.AddWithValue("@bairro_funcionario", model.bairro_funcionario);
            command.Parameters.AddWithValue("@dataadmissao_funcionario", model.dataAdmissao_funcionario);
            command.Parameters.AddWithValue("@datanasc_funcionario", model.dataNasc_funcionario);
            command.Parameters.AddWithValue("@genero_funcionario", model.genero_funcionario);
            command.Parameters.AddWithValue("@telefone_funcionario", model.telefone_funcionario);
            command.Parameters.AddWithValue("@fk_id_cargo", model.fk_id_cargo);

            ConnectionDB.CRUD(command);
        }

        public void update(Funcionario model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE Funcionario SET nome_funcionario=@nome_funcionario, rg_funcionario=@rg_funcionario, cpf_funcionario=@cpf_funcionario, endereco_funcionario=@endereco_funcionario, numero_endereco_funcionario=@numero_endereco_funcionario, bairro_funcionario=@bairro_funcionario, dataadmissao_funcionario=@dataadmissao_funcionario, datanasc_funcionario=@datanasc_funcionario, genero_funcionario=@genero_funcionario, telefone_funcionario=@telefone_funcionario, fk_id_cargo=@fk_id_cargo " +
                                                 "WHERE id_funcionario=@id_funcionario";

            command.Parameters.AddWithValue("@nome_funcionario", model.nome_funcionario);
            command.Parameters.AddWithValue("@rg_funcionario", model.rg_funcionario);
            command.Parameters.AddWithValue("@cpf_funcionario", model.cpf_funcionario);
            command.Parameters.AddWithValue("@endereco_funcionario", model.endereco_funcionario);
            command.Parameters.AddWithValue("@numero_endereco_funcionario", model.numero_endereco_funcionario);
            command.Parameters.AddWithValue("@bairro_funcionario", model.bairro_funcionario);
            command.Parameters.AddWithValue("@dataadmissao_funcionario", model.dataAdmissao_funcionario);
            command.Parameters.AddWithValue("@datanasc_funcionario", model.dataNasc_funcionario);
            command.Parameters.AddWithValue("@genero_funcionario", model.genero_funcionario);
            command.Parameters.AddWithValue("@telefone_funcionario", model.telefone_funcionario);
            command.Parameters.AddWithValue("@fk_id_cargo", model.fk_id_cargo);

            command.Parameters.AddWithValue("@id_funcionario", model.id_funcionario);
            ConnectionDB.CRUD(command);
        }

        public NpgsqlDataReader select(Usuario model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Funcionario ORDER BY id_funcionario";

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            return dr;
        }

        public Funcionario selectById(Funcionario model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Funcionario WHERE id_funcionario=@id_funcionario";

            command.Parameters.AddWithValue("@id_funcionario", model.id_funcionario);

            NpgsqlDataReader dr = ConnectionDB.Select(command);

            if(dr.HasRows)
            {
                dr.Read();
                model.id_funcionario = (int)dr["id_funcionario"];
                model.nome_funcionario = (string)dr["nome_funcionario"];
                model.rg_funcionario = (string)dr["rg_funcionario"];
                model.cpf_funcionario = (string)dr["cpf_funcionario"];
                model.endereco_funcionario = (string)dr["endereco_funcionario"];
                model.numero_endereco_funcionario = (int)dr["numero_endereco_funcionario"];
                model.bairro_funcionario = (string)dr["bairro_funcionario"];
                model.id_funcionario = (int)dr["id_funcionario"];
                model.genero_funcionario = (string)dr["genero_funcionario"];
                model.telefone_funcionario = (string)dr["telefone_funcionario"];
                model.fk_id_cargo = (int)dr["fk_id_cargo"];
            }

            return model;

            
        }

        public void delete(int id_funcionario)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM Funcionario WHERE id_funcionario=@id_funcionario";

            command.Parameters.AddWithValue("@id_funcionario", id_funcionario);

            ConnectionDB.CRUD(command);
        }
    }
}
