using Project.Domain.Entities;
using Project.Infra.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project.Infra.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IDisposable
    {
        public EnderecoRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void Adicionar(Endereco endereco)
        {
            Add(endereco);
        }

        public override void MapAddCommandParameters(Endereco entity, SqlCommand sqlCommand)
        {
            string queryAdd = $"insert into Endereco (logradouro, bairro, cidade, estado) values(@logradouro, @bairro, @cidade, @estado)";
            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryAdd;
            SqlConnection.Open();
        }

        public IEnumerable<Endereco> Get()
        {
            return GetAll();
        }

        public override IEnumerable<Endereco> MapGetAllCommandParameters(SqlCommand sqlCommand)
        {
            string queryGetAll = @"Select * from Endereco";

            List<Endereco> enderecos = new List<Endereco>();

            SqlCommand.CommandType = CommandType.Text;
            SqlCommand.CommandText = queryGetAll;
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
            return enderecos;
        }

        public Endereco GetById(long id)
        {
            return Get(id);
        }

        public override Endereco MapGetByIdCommandParameters(SqlCommand sqlCommand, long id)
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
            return endereco;
        }

        public void Remover(Endereco obj)
        {
            Remove(obj);
        }

        public override void MapRemoveCommandParameters(Endereco entity, SqlCommand sqlCommand)
        {
            string queryDelete = "delete from Endereco where id = @enderecoId";

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = queryDelete;
            sqlCommand.Parameters.AddWithValue("@enderecoId", entity.Id);
        }

        public void Atualizar(Endereco obj)
        {
            Update(obj);
        }

        public override void MapUpdateCommandParameters(Endereco entity, SqlCommand sqlCommand)
        {
            string queryUpdate = "update Endereco set logradouro = @logradouro, bairro = @bairro, cidade = @cidade, estado = @estado where id = @enderecoId";

            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = queryUpdate;

            sqlCommand.Parameters.AddWithValue("@id", entity.Id);
            sqlCommand.Parameters.AddWithValue("@logradouro", entity.Logradouro);
            sqlCommand.Parameters.AddWithValue("@bairro", entity.Bairro);
            sqlCommand.Parameters.AddWithValue("@cidade", entity.Cidade);
            sqlCommand.Parameters.AddWithValue("@estado", entity.Estado);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
