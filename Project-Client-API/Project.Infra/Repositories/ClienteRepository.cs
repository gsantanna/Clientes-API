using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.Infra.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Adicionar(Cliente cliente)
        {
            Add(cliente);
        }

        public override void MapAddCommandParameters(Cliente entity)
        {
            string queryAdd = $"insert into cliente (nome, cpf, idade, datanascimento) values(@nome, @cpf, @idade, @datanascimento)";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryAdd;
            SqlCommand.Parameters.AddWithValue("@nome", entity.Nome);
            SqlCommand.Parameters.AddWithValue("@cpf", entity.Cpf);
            SqlCommand.Parameters.AddWithValue("@idade", entity.Idade);
            SqlCommand.Parameters.AddWithValue("@datanascimento", entity.DataNascimento);
        }

        public IEnumerable<Cliente> Get()
        {
            return GetAll();
        }

        public override IEnumerable<Cliente> MapGetAllCommandParameters()
        {
            string queryGetAll = @"Select * from Cliente";

            List<Cliente> clientes = new List<Cliente>();

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryGetAll;

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
            SqlDataReader.Close();

            return clientes;
        }

        public Cliente GetById(long id)
        {
            return Get(id);
        }

        public Cliente GetByCpf(string cpf)
        {
            return GetByCpf(cpf);
        }

        public override Cliente MapGetByIdCommandParameters(long id)
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
            SqlDataReader.Close();

            return cliente;
        }

        public void Remover(Cliente obj)
        {
            Remove(obj);
        }

        public override void MapRemoveCommandParameters(Cliente entity)
        {
            string queryDelete = "delete from cliente where id = @id";

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryDelete;
            SqlCommand.Parameters.AddWithValue("@id", entity.Id);
        }

        public void Atualizar(Cliente obj)
        {
            Update(obj);
        }

        public override void MapUpdateCommandParameters(Cliente entity)
        {
            string queryUpdate = "update cliente set nome = @nome, cpf = @cpf, idade = @idade, datanascimento = @datanascimento where id = @clienteId";

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryUpdate;

            SqlCommand.Parameters.AddWithValue("@id", entity.Id);
            SqlCommand.Parameters.AddWithValue("@nome", entity.Nome);
            SqlCommand.Parameters.AddWithValue("@cpf", entity.Cpf);
            SqlCommand.Parameters.AddWithValue("@idade", entity.Idade);
            SqlCommand.Parameters.AddWithValue("@datanascimento", entity.DataNascimento);
        }
    }
}
