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
    public class prestar_servicoDAO
    {
        public void insert(prestar_servico model)
        {
            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO prestar_servico (data_execucao, fk_id_servico, fk_id_pet, fk_id_funcionario, fk_id_pedido, status_servico) " +
                                             "VALUES (@data_execucao, @fk_id_servico, @fk_id_pet, @fk_id_funcionario, @fk_id_pedido, @status_servico)";

            command.Parameters.AddWithValue("@data_execucao", Convert.ToDateTime(model.data_execucao));
            command.Parameters.AddWithValue("@fk_id_servico", model.fk_id_servico);
            command.Parameters.AddWithValue("@fk_id_pet", model.fk_id_pet);
            command.Parameters.AddWithValue("@fk_id_funcionario", model.fk_id_funcionario);
            command.Parameters.AddWithValue("@fk_id_pedido", model.fk_id_pedido);
            command.Parameters.AddWithValue("@status_servico", model.status_servico);
            
            ConnectionDB.CRUD(command);
        }
    }
}
