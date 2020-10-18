using Project.Domain.Entities;
using Project.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IDisposable
    {
        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Adicionar(Cliente cliente)
        {
            Add(cliente);
        }

        public override void MapAddCommandParameters(Cliente entity, SqlCommand sqlCommand)
        {
            string queryAdd = $"insert into cliente (nome, cpf, idade, datanascimento) values(@nome, @cpf, @idade, @datanascimento)";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryAdd;
            SqlConnection.Open();
        }

        public IEnumerable<Cliente> Get()
        {
            return GetAll();
        }

        public override IEnumerable<Cliente> MapGetAllCommandParameters(SqlCommand sqlCommand)
        {
            string queryGetAll = @"Select * from Cliente";

            List<Cliente> clientes = new List<Cliente>();

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryGetAll;
            SqlConnection.Open();

            SqlDataReader = SqlCommand.ExecuteReader();

            if (SqlDataReader.HasRows)
            {
                while (SqlDataReader.Read())
                {
                    clientes.Add(new Cliente(
                        Convert.ToInt64(SqlDataReader["Id"].ToString()),
                        SqlDataReader["Nome"].ToString(),
                        SqlDataReader["Cpf"].ToString(),
                        Convert.ToInt32(SqlDataReader["Idade"]),
                        Convert.ToDateTime(SqlDataReader["DataNascimento"])
                        ));
                }
            }
            return clientes;
        }

        public Cliente GetById(long id)
        {
            return Get(id);
        }

        public override Cliente MapGetByIdCommandParameters(SqlCommand sqlCommand, long id)
        {
            string queryGetById = @"Select * from Cliente 
                           Where Id = @clienteId";

            Cliente cliente = null;
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryGetById;
            SqlCommand.Parameters.AddWithValue("@clienteId", id);

            SqlDataReader = SqlCommand.ExecuteReader();

            if (SqlDataReader.HasRows)
            {
                while (SqlDataReader.Read())
                {
                    cliente = new Cliente(
                        Convert.ToInt64(SqlDataReader["Id"].ToString()),
                        SqlDataReader["Nome"].ToString(),
                        SqlDataReader["Cpf"].ToString(),
                        Convert.ToInt32(SqlDataReader["Idade"]),
                        Convert.ToDateTime(SqlDataReader["DataNascimento"])
                        );
                }
            }
            return cliente;
        }

        public void Remover(Cliente obj)
        {
            Remove(obj);
        }

        public override void MapRemoveCommandParameters(Cliente entity, SqlCommand sqlCommand)
        {
            string queryDelete = "delete from cliente where id = @clienteId";

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = queryDelete;
            sqlCommand.Parameters.AddWithValue("@clienteId", entity.Id);
        }

        public void Atualizar(Cliente obj)
        {
            Update(obj);
        }

        public override void MapUpdateCommandParameters(Cliente entity, SqlCommand sqlCommand)
        {
            string queryUpdate = "update cliente set nome = @nome, cpf = @cpf, idade = @idade, datanascimento = @datanascimento where id = @clienteId";

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = queryUpdate;

            sqlCommand.Parameters.AddWithValue("@id", entity.Id);
            sqlCommand.Parameters.AddWithValue("@nome", entity.Nome);
            sqlCommand.Parameters.AddWithValue("@cpf", entity.Cpf);
            sqlCommand.Parameters.AddWithValue("@idade", entity.Idade);
            sqlCommand.Parameters.AddWithValue("@datanascimento", entity.DataNascimento);
        }

        public void Dispose()
        {
            _unitOfWork.DataContext.Dispose();
        }
    }
}
