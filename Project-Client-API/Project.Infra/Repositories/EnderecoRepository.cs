using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.Infra.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Adicionar(Endereco endereco)
        {
            Add(endereco);
        }

        public override void MapAddCommandParameters(Endereco entity)
        {
            string queryAdd = $"insert into Endereco (logradouro, bairro, cidade, estado) values(@logradouro, @bairro, @cidade, @estado)";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryAdd;
            SqlCommand.Parameters.AddWithValue("@logradouro", entity.Logradouro);
            SqlCommand.Parameters.AddWithValue("@bairro", entity.Bairro);
            SqlCommand.Parameters.AddWithValue("@cidade", entity.Cidade);
            SqlCommand.Parameters.AddWithValue("@estado", entity.Estado);
        }

        public IEnumerable<Endereco> Get()
        {
            return GetAll();
        }

        public override IEnumerable<Endereco> MapGetAllCommandParameters()
        {
            string queryGetAll = @"Select * from Endereco";

            List<Endereco> enderecos = new List<Endereco>();

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryGetAll;
            SqlConnection.Close();
            SqlConnection.Open();

            SqlDataReader = SqlCommand.ExecuteReader();

            if (SqlDataReader.HasRows)
            {
                while (SqlDataReader.Read())
                {
                    enderecos.Add(new Endereco(
                        Convert.ToInt64(SqlDataReader["Id"].ToString()),
                        SqlDataReader["Logradouro"].ToString(),
                        SqlDataReader["Bairro"].ToString(),
                        SqlDataReader["Cidade"].ToString(),
                        SqlDataReader["Estado"].ToString()
                        ));
                }
            }
            SqlDataReader.Close();

            return enderecos;
        }

        public Endereco GetById(long id)
        {
            return Get(id);
        }

        public override Endereco MapGetByIdCommandParameters(long id)
        {
            string queryGetById = @"Select * from Endereco 
                           Where Id = @enderecoId";

            Endereco endereco = null;
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryGetById;
            SqlCommand.Parameters.AddWithValue("@enderecoId", id);

            SqlDataReader = SqlCommand.ExecuteReader();

            if (SqlDataReader.HasRows)
            {
                while (SqlDataReader.Read())
                {
                    endereco = new Endereco(
                        Convert.ToInt64(SqlDataReader["Id"].ToString()),
                        SqlDataReader["Logradouro"].ToString(),
                        SqlDataReader["Bairro"].ToString(),
                        SqlDataReader["Cidade"].ToString(),
                        SqlDataReader["Estado"].ToString()
                        );
                }
            }
            SqlDataReader.Close();

            return endereco;
        }

        public void Remover(Endereco obj)
        {
            Remove(obj);
        }

        public override void MapRemoveCommandParameters(Endereco entity)
        {
            string queryDelete = "delete from Endereco where id = @Id";

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryDelete;
            SqlCommand.Parameters.AddWithValue("@Id", entity.Id);
        }

        public void Atualizar(Endereco obj)
        {
            Update(obj);
        }

        public override void MapUpdateCommandParameters(Endereco entity)
        {
            string queryUpdate = "update Endereco set logradouro = @logradouro, bairro = @bairro, cidade = @cidade, estado = @estado where id = @enderecoId";

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryUpdate;

            SqlCommand.Parameters.AddWithValue("@id", entity.Id);
            SqlCommand.Parameters.AddWithValue("@logradouro", entity.Logradouro);
            SqlCommand.Parameters.AddWithValue("@bairro", entity.Bairro);
            SqlCommand.Parameters.AddWithValue("@cidade", entity.Cidade);
            SqlCommand.Parameters.AddWithValue("@estado", entity.Estado);
        }
    }
}
