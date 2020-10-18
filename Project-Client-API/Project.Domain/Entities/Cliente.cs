using System;

namespace Project.Domain.Entities
{
    public class Cliente
    {
        public long Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
        public int Idade { get; protected set; }
        public DateTime DataNascimento { get; protected set; }

        public Cliente() { }

        public Cliente(long id, string nome, string cpf, int idade, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            DataNascimento = dataNascimento;
        }
    }
}
